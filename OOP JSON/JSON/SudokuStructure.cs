namespace JSON
{
    class SudokuStructure : IPattern
    {
        private readonly IPattern pattern;

        public SudokuStructure()
        {
            var whiteSpace = new Many(new Character(' '));
            var newLine = new Text("\r\n");
            var element = new Sequence(whiteSpace, new Range('1', '9'), whiteSpace);

            var row = new Sequence(element,
                                   element,
                                   element,
                                   element,
                                   element,
                                   element,
                                   element,
                                   element,
                                   element);

            var matrix = new Sequence(row, newLine,
                                      row, newLine,
                                      row, newLine,
                                      row, newLine,
                                      row, newLine,
                                      row, newLine,
                                      row, newLine,
                                      row, newLine,
                                      row);
            pattern = matrix;
        }


        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
