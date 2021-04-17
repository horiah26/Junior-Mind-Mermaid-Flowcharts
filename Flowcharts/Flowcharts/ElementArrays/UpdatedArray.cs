namespace Flowcharts
{
    class UpdatedArray : IElementArray
    {
        public Element[,] ElementArray { get; private set; }

        public UpdatedArray(Element[,] elementArray)
        {
            this.ElementArray = elementArray;
        }

        public Element[,] Update()
        {
            for (int i = 0; i < ElementArray.GetLength(0); i++)
            {
                for (int j = 0; j < ElementArray.GetLength(1); j++)
                {
                    if (ElementArray[i, j] != null)
                    {
                        ElementArray[i, j].Row = i;
                        ElementArray[i, j].Column = j;
                    }
                }
            }

            UpdateParentsChildren();
            return ElementArray;
        }

        public void UpdateParentsChildren()
        {
            foreach (var element in ElementArray)
            {
                foreach (var element2 in ElementArray)
                {
                    if (element != null && element2 != null)
                    {
                        for(int i = 0; i < element.childElements.Count; i++)
                        {
                            if (element2.Key == element.childElements[i].Key)
                            {
                                element.childElements[i] = element2;
                            }
                        }

                        for (int i = 0; i < element.parentElements.Count; i++)
                        {
                            if (element2.Key == element.parentElements[i].Key)
                            {
                                element.parentElements[i] = element2;
                            }
                        }
                    }
                }
            }
        }
    }
}