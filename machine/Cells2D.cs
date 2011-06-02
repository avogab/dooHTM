using System;
using System.Collections.Generic;

namespace Doo.Machine
{
    // This class is utilized to group cells arranged by a two-dimensional matrix.
    // The comunser of this class typically ignore the width and height of the underneath matrix
    // so to access each element it will use the indexer: T this[double x, double y].
    public class Cells2D<T> where T : ISpatialCell, new()
    {
        T[,] _cells;
        
        public T this[int ix, int iy]
        {
            get { return _cells[ix, iy]; }
        }

        // Return the nearest cell with x, y coordinates.
        // param x: a value between 0 to 1 long the first coordinate
        // param y: a value between 0 to 1 long the second coordinate
        // Of course two o more cells could be equidistant, for the moment this situation isn't managed and the routine will return the one's with the lowest index.
        public T this[double x, double y]
        {
            get
            {
                if (x < 0 || x > 1 || y < 0 || y > 1)
                    throw new ArgumentException("Invalid x or y argument.");
                return _cells[(int)(x * (Width - 1)), (int)(y * (Height - 1))];
            }
        }

        public int Width { get { return _cells.GetLength(0); } }
        public int Height { get { return _cells.GetLength(1); } }

        public Cells2D()
        {
        }

        public Cells2D(int width, int height)
        {
            _cells = new T[width, height];
            for (int ix = 0; ix < width; ix++)
                for (int iy = 0; iy < height; iy++)
                {
                    _cells[ix, iy] = new T();
                    _cells[ix, iy].X = (double)ix / (double)(width - 1);
                    _cells[ix, iy].Y = (double)iy / (double)(height - 1);
                }
        }
        
        public Cells2D<T> Clone()
        {
            Cells2D<T> newCells = new Cells2D<T>();
            newCells._cells = new T[Width, Height];
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                {
                    newCells._cells[x, y] = new T();
                    newCells._cells[x, y].SetActive(_cells[x, y].GetActive(0));
                }
            return newCells;
        }

        public List<T> GetRectangle(double x, double y, int width, int height)
        {
            // Locate the index of the central cell.
            int ix = (int)(x * (Width - 1));
            int iy = (int)(y * (Height - 1));
            
            int minX = Math.Max(0, ix - width / 2);
            int maxX = Math.Min(Width - 1, ix + width / 2);
            int minY = Math.Max(0, iy - height / 2);
            int maxY = Math.Min(Height - 1, iy + height / 2);
            List<T> list = new List<T>();
            for (int xx = minX; xx <= maxX; xx++)
                for (int yy = minY; yy <= maxY; yy++)
                    list.Add(_cells[xx, yy]);
            return list;
        }
    }
}
