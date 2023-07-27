namespace _2250._Count_Number_of_Rectangles_Containing_Each_Point
{
    internal class Program
    {
        static public int[] CountRectangles(int[][] rectangles, int[][] points)
        {
            int i = 0 ;
            int[][] sortedRectangles = rectangles.OrderBy(x => x[0]).ThenBy(x => x[1]).ToArray();

            int[] pointsCount = new int[points.Length];

            Dictionary<int, List <int[]> > rectanglesByHeight = new Dictionary<int, List<int[]>>();
            foreach (var rectangle in rectangles)
            {
                if (!rectanglesByHeight.ContainsKey(rectangle[1])) rectanglesByHeight.Add(rectangle[1], RectanglesWithHeight(rectangles, rectangle[1]));
                
            }

            foreach (var point in points)
            {
                pointsCount[i] += CountPointInRectangles(point, rectanglesByHeight);
                i++;
            }


            return pointsCount;
        }
        static public bool PointInRectangle(int[] point , int[] rectangle) //confirmed
        {
            return point[0] <= rectangle[0] && point[1] <= rectangle[1];
        }

        

        static public List<int[]> RectanglesWithHeight(int[][] rectangles, int height) //confirmed
        {
            return rectangles.Where(r => r[1] == height).OrderBy(r => r[0]).ToList();
        }

        static public int CountPointInRectanglesWithHeight(int[] point, List<int[]> rectangles, int height) //confirmed
        {
            int i = 0;
            
            while (!PointInRectangle(point, rectangles[i]))
            {
                
                if (i == rectangles.Count - 1) return 0;
                i++;
            }
            return rectangles.Count - i;
        }
        static public int CountPointInRectangles(int[] point, Dictionary<int, List<int[]>> rectangles) //confirmed
        {
            int i = 0;
            foreach (var item in rectangles)
            {
                i += CountPointInRectanglesWithHeight(point, item.Value, item.Key);
            }
            return i;
        }



        static void Main(string[] args)
        {
            var dict = new Dictionary<int, List<int[]>>();
            dict.Add(1, new List<int[]>
            {
                new int[] { 1, 1 },
                new int[] { 2, 1 },
                new int[] { 3, 1 },
                new int[] { 4, 1 },
                new int[] { 5, 1 },
            });
            dict.Add(2, new List<int[]>
            {
                new int[] { 1, 2 },
                new int[] { 2, 2 },
                new int[] { 3, 2 },
                new int[] { 4, 2 },
                new int[] { 5, 2 },
            });
            dict.Add(4, new List<int[]>
            {
                new int[] { 1, 4 },
                new int[] { 2, 4 },
                new int[] { 3, 4 },
                new int[] { 4, 4 },
                new int[] { 5, 4 },
            });

            ;
            List<int[]> rectanglesWithHeight = new List<int[]>
            {
                new int[] { 1, 1 },
                new int[] { 2, 1 },
                new int[] { 3, 1 },
                new int[] { 4, 1 },
                new int[] { 5, 1 },
            };

            int[] point = new int[] { 4, 4 };
            int[] rectangle = new int[] { 2, 3 };

            int[][] rectangles = new int[][] {
                new int[] {1,1},
                new int[] {3,2},
                new int[] {2,2},

            };
            int[][] points = new int[][] {
                new int[] {1,1},
                new int[] {1,3},



            };
            /*var newRectangles = RectanglesWithHeight(rectangles, 2);
            foreach (var rect in newRectangles)
            {
                Console.WriteLine(rect[0] + " " + rect[1]);
            }*/

            /*int[] result = CountRectangles(rectangles, points);
            foreach (var item in result)
            {
                Console.WriteLine(item);  
            }*/
            //Console.WriteLine(CountPointInRectangles(point, dict));
            //Console.WriteLine(PointInRectangle(point, rectangle));
            /*foreach (int[] rectangle in sortedRectangles)
            
            {
                Console.WriteLine(rectangle[0] + " " + rectangle[1]);
            }*/
        }
    }
}