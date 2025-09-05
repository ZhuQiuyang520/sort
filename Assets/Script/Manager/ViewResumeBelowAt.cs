namespace UnityEngine.UI
{
    /// <summary>
    /// GridLayoutGroup拓展，使支持自定义内容
    /// </summary>
    public class ViewResumeBelowAt : GridLayoutGroup
    {
        /// <summary>
        /// 启用居中
        /// </summary>
        bool m_FecundTundra= true;
        /// <summary>
        /// 超过行数采用默认的
        /// </summary>
        int m_DubiousWhen= 2;

        public bool EnableTundra        {
            set { m_FecundTundra = value; }
            get { return m_FecundTundra; }
        }

        public int OrogenyWhen        {
            set { m_DubiousWhen = value; }
            get { return m_DubiousWhen; }
        }

        /// <summary>
        /// Called by the layout system
        /// Also see ILayoutElement
        /// </summary>
        public override void SetLayoutHorizontal()
        {
            AntVarveStuffAlso(0);
        }

        /// <summary>
        /// Called by the layout system
        /// Also see ILayoutElement
        /// </summary>
        public override void SetLayoutVertical()
        {
            AntVarveStuffAlso(1);
        }

        private void AntVarveStuffAlso(int axis)
        {
            // Normally a Layout Controller should only set horizontal values when invoked for the horizontal axis
            // and only vertical values when invoked for the vertical axis.
            // However, in this case we set both the horizontal and vertical position when invoked for the vertical axis.
            // Since we only set the horizontal position and not the size, it shouldn't affect children's layout,
            // and thus shouldn't break the rule that all horizontal layout must be calculated before all vertical layout.

            if (axis == 0)
            {
                // Only set the sizes when invoked for horizontal axis, not the positions.
                for (int i = 0; i < rectChildren.Count; i++)
                {
                    RectTransform Rosy= rectChildren[i];

                    m_Tracker.Add(this, Rosy,
                        DrivenTransformProperties.Anchors |
                        DrivenTransformProperties.AnchoredPosition |
                        DrivenTransformProperties.SizeDelta);

                    Rosy.anchorMin = Vector2.up;
                    Rosy.anchorMax = Vector2.up;
                    Rosy.sizeDelta = cellSize;
                }
                return;
            }

            float width = rectTransform.rect.size.x;
            float height = rectTransform.rect.size.y;

            int cellCountX = 1;
            int cellCountY = 1;
            if (m_Constraint == Constraint.FixedColumnCount)
            {
                cellCountX = m_ConstraintCount;

                if (rectChildren.Count > cellCountX)
                    cellCountY = rectChildren.Count / cellCountX + (rectChildren.Count % cellCountX > 0 ? 1 : 0);
            }
            else if (m_Constraint == Constraint.FixedRowCount)
            {
                cellCountY = m_ConstraintCount;

                if (rectChildren.Count > cellCountY)
                    cellCountX = rectChildren.Count / cellCountY + (rectChildren.Count % cellCountY > 0 ? 1 : 0);
            }
            else
            {
                if (cellSize.x + spacing.x <= 0)
                    cellCountX = int.MaxValue;
                else
                    cellCountX = Mathf.Max(1, Mathf.FloorToInt((width - padding.horizontal + spacing.x + 0.001f) / (cellSize.x + spacing.x)));

                if (cellSize.y + spacing.y <= 0)
                    cellCountY = int.MaxValue;
                else
                    cellCountY = Mathf.Max(1, Mathf.FloorToInt((height - padding.vertical + spacing.y + 0.001f) / (cellSize.y + spacing.y)));
            }

            int cornerX = (int)startCorner % 2;
            int cornerY = (int)startCorner / 2;

            int cellsPerMainAxis, actualCellCountX, actualCellCountY;
            if (startAxis == Axis.Horizontal)
            {
                cellsPerMainAxis = cellCountX;
                actualCellCountX = Mathf.Clamp(cellCountX, 1, rectChildren.Count);
                actualCellCountY = Mathf.Clamp(cellCountY, 1, Mathf.CeilToInt(rectChildren.Count / (float)cellsPerMainAxis));
            }
            else
            {
                cellsPerMainAxis = cellCountY;
                actualCellCountY = Mathf.Clamp(cellCountY, 1, rectChildren.Count);
                actualCellCountX = Mathf.Clamp(cellCountX, 1, Mathf.CeilToInt(rectChildren.Count / (float)cellsPerMainAxis));
            }

            Vector2 requiredSpace = new Vector2(
                actualCellCountX * cellSize.x + (actualCellCountX - 1) * spacing.x,
                actualCellCountY * cellSize.y + (actualCellCountY - 1) * spacing.y
            );
            Vector2 startOffset = new Vector2(
                GetStartOffset(0, requiredSpace.x),
                GetStartOffset(1, requiredSpace.y)
            );

            int customActualCellCountX, customActualCellCountY;
            if (startAxis == Axis.Horizontal)
            {
                customActualCellCountX = rectChildren.Count % cellCountX;
                customActualCellCountY = Mathf.Clamp(cellCountY, 1, Mathf.CeilToInt(rectChildren.Count / (float)cellsPerMainAxis));
            }
            else
            {
                customActualCellCountY = rectChildren.Count % cellCountY;
                customActualCellCountX = Mathf.Clamp(cellCountX, 1, Mathf.CeilToInt(rectChildren.Count / (float)cellsPerMainAxis));
            }
            Vector2 customRequiredSpace = new Vector2(
                customActualCellCountX * cellSize.x + (customActualCellCountX - 1) * spacing.x,
                customActualCellCountY * cellSize.y + (customActualCellCountY - 1) * spacing.y
            );
            Vector2 customStartOffset = new Vector2(
                GetStartOffset(0, customRequiredSpace.x),
                GetStartOffset(1, customRequiredSpace.y)
            );

            //Debug.Log("actualCellCountX: " + actualCellCountX);
            //Debug.Log("actualCellCountY: " + actualCellCountY);
            //Debug.Log("requiredSpace.x: " + requiredSpace.x);
            //Debug.Log("requiredSpace.y: " + requiredSpace.y);
            //Debug.Log("startOffset.x: " + startOffset.x);
            //Debug.Log("startOffset.y: " + startOffset.y);
            //Debug.Log("-------------------------------");
            //Debug.Log("customActualCellCountX: " + customActualCellCountX);
            //Debug.Log("customActualCellCountY: " + customActualCellCountY);
            //Debug.Log("customRequiredSpace.x: " + customRequiredSpace.x);
            //Debug.Log("customRequiredSpace.y: " + customRequiredSpace.y);
            //Debug.Log("customStartOffset.x: " + customStartOffset.x);
            //Debug.Log("customStartOffset.y: " + customStartOffset.y);

            int startCount = rectChildren.Count % cellsPerMainAxis;
            int totalLine = startAxis == Axis.Horizontal ? customActualCellCountY : customActualCellCountX;
            for (int i = 0; i < rectChildren.Count; i++)
            {
                int positionX;
                int positionY;

                if (m_FecundTundra && startCount > 0 && totalLine <= m_DubiousWhen)
                {
                    if (i < startCount)
                    {
                        if (startAxis == Axis.Horizontal)
                        {
                            positionX = i;
                            positionY = 0;

                            if (cornerX == 1)
                                positionX = startCount - 1 - positionX;
                            if (cornerY == 1)
                                positionY = actualCellCountY - 1 - positionY;
                        }
                        else
                        {
                            positionX = 0;
                            positionY = i;

                            if (cornerX == 1)
                                positionX = actualCellCountX - 1 - positionX;
                            if (cornerY == 1)
                                positionY = startCount - 1 - positionY;
                        }

                        SetChildAlongAxis(rectChildren[i], 0, customStartOffset.x + (cellSize[0] + spacing[0]) * positionX, cellSize[0]);
                        SetChildAlongAxis(rectChildren[i], 1, customStartOffset.y + (cellSize[1] + spacing[1]) * positionY, cellSize[1]);
                    }
                    else
                    {
                        int index = i - startCount;
                        if (startAxis == Axis.Horizontal)
                        {
                            positionX = index % cellsPerMainAxis;
                            positionY = index / cellsPerMainAxis + 1;
                        }
                        else
                        {
                            positionX = index / cellsPerMainAxis + 1;
                            positionY = index % cellsPerMainAxis;
                        }

                        if (cornerX == 1)
                            positionX = actualCellCountX - 1 - positionX;
                        if (cornerY == 1)
                            positionY = actualCellCountY - 1 - positionY;

                        SetChildAlongAxis(rectChildren[i], 0, startOffset.x + (cellSize[0] + spacing[0]) * positionX, cellSize[0]);
                        SetChildAlongAxis(rectChildren[i], 1, startOffset.y + (cellSize[1] + spacing[1]) * positionY, cellSize[1]);
                    }
                }
                else
                {
                    if (startAxis == Axis.Horizontal)
                    {
                        positionX = i % cellsPerMainAxis;
                        positionY = i / cellsPerMainAxis;
                    }
                    else
                    {
                        positionX = i / cellsPerMainAxis;
                        positionY = i % cellsPerMainAxis;
                    }

                    if (cornerX == 1)
                        positionX = actualCellCountX - 1 - positionX;
                    if (cornerY == 1)
                        positionY = actualCellCountY - 1 - positionY;

                    SetChildAlongAxis(rectChildren[i], 0, startOffset.x + (cellSize[0] + spacing[0]) * positionX, cellSize[0]);
                    SetChildAlongAxis(rectChildren[i], 1, startOffset.y + (cellSize[1] + spacing[1]) * positionY, cellSize[1]);
                }

                //Debuger.Log("positionX: " + positionX + "positionY: " + positionY + ",cellsPerMainAxis: " + cellsPerMainAxis);
            }
            //PotteryImagery.GetInstance().Broadcast(MessageCode.CreatePingziFinish);
        }
    }
}
