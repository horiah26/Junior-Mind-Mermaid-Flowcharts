namespace Flowcharts
{
    class UpdatedArray
    {
        readonly Element[,] elementArray;

        public UpdatedArray(Element[,] elementArray)
        {
            this.elementArray = elementArray;
        }

        public Element[,] Update()
        {
            for (int i = 0; i < elementArray.GetLength(0); i++)
            {
                for (int j = 0; j < elementArray.GetLength(1); j++)
                {
                    if (elementArray[i, j] != null)
                    {
                        elementArray[i, j].Row = i;
                        elementArray[i, j].Column = j;
                    }
                }
            }

            UpdateParentsChildren();
            return elementArray;
        }

        public void UpdateParentsChildren()
        {
            foreach (var element in elementArray)
            {
                foreach (var element2 in elementArray)
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