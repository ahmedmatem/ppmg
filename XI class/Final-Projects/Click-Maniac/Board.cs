using System.Windows.Forms;
using static Click_Maniac.Constants;

namespace Click_Maniac
{
    public class Board
    {
        private int level;
        private int tilesInRow, tilesInCol;

        private Tile[,] tiles;

        public Board(int _level)
        {
            level = _level;
            tilesInRow = TilesInRow + level;
            tilesInCol = tilesInRow;
            tiles = new Tile[tilesInRow, tilesInCol];
        }

        public Board CreatTiles()
        {
            int tileSize = (BoardSize - (TilesInRow + 1) * Gap) / tilesInRow;

            for (int row = 0; row < tilesInRow; row++)
            {
                for (int col = 0; col < tilesInCol; col++)
                {
                    Point location = new Point()
                    {
                        X = (col + 1) * Gap + col * tileSize,
                        Y = (row + 1) * Gap + row * tileSize
                    };
                    Tile tile = new Tile()
                    {
                        BackColor = TileBackColor,
                        Size = new Size(tileSize, tileSize),
                        Location = location,
                        Row = row,
                        Col = col
                    };

                    tiles[row, col] = tile;
                }
            }

            return this;
        }

        public void LoadIn(Panel board)
        {
            foreach (var tile in tiles)
            {
                board.Controls.Add(tile);
            }
        }
    }
}
