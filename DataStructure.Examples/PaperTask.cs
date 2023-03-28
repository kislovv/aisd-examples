using System.Reflection;

namespace DataStructure.Examples;

public class PaperTask
{
    public int GetAreasCount(int[,] matrix)
    {
        var areaCount = 0;
        var queue = new NodeQueue<Point>();

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; i < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == 0)
                {
                    areaCount++;
                    queue.Enqueue(new Point(i, j));
                    do
                    {
                        CheckNeighbour(matrix, queue, areaCount);

                    } while (!queue.IsEmpty);
                }
            }
        }

        return areaCount;
    }

    private void CheckNeighbour(int[,] matrix, NodeQueue<Point> queue, int areaCount)
    {
        var point = queue.Dequeue();
        if (IsOnMatrix(new Point(point.x - 1, point.y), matrix) && matrix[point.x - 1, point.y] == 0)
        {
            matrix[point.x - 1, point.y] = areaCount;
            queue.Enqueue(new Point(point.x - 1, point.y));
        }
        if (IsOnMatrix(new Point(point.x + 1, point.y), matrix) && matrix[point.x + 1, point.y] == 0)
        {
            matrix[point.x + 1, point.y] = areaCount;
            queue.Enqueue(new Point(point.x + 1, point.y));
        }
        if (IsOnMatrix(new Point(point.x, point.y - 1), matrix) && matrix[point.x, point.y - 1] == 0)
        {
            matrix[point.x, point.y - 1] = areaCount;
            queue.Enqueue(new Point(point.x, point.y - 1));
        }
        if (IsOnMatrix(new Point(point.x, point.y + 1), matrix) && matrix[point.x, point.y + 1] == 0)
        {
            matrix[point.x, point.y + 1] = areaCount;
            queue.Enqueue(new Point(point.x, point.y + 1));
        }
        
    }

    private bool IsOnMatrix(Point point, int[,] matrix)
    {
        return point.x >= 0 && point.x < matrix.GetLength(0) && point.y >= 0 && point.y < matrix.GetLength(1);
    }
}