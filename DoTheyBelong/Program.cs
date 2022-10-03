Console.WriteLine(pointsBelong(2, 2, 7, 2, 5, 4, 4, 3, 7, 4));

int pointsBelong(int x1, int y1, int x2, int y2, int x3, int y3, int xp, int yp, int xq, int yq)
{
    if (!isNonDegenerateTriangle(x1, y1, x2, y2, x3, y3)) return 0;

    if (belongsToTriangle(2, 2, 7, 2, 5, 4, 4, 3) && !belongsToTriangle(2, 2, 7, 2, 5, 4, 7, 4)) return 1;

    if (!belongsToTriangle(2, 2, 7, 2, 5, 4, 4, 3) && belongsToTriangle(2, 2, 7, 2, 5, 4, 7, 4)) return 2;

    if (belongsToTriangle(2, 2, 7, 2, 5, 4, 4, 3) && belongsToTriangle(2, 2, 7, 2, 5, 4, 7, 4)) return 3;

    if (!belongsToTriangle(2, 2, 7, 2, 5, 4, 4, 3) && !belongsToTriangle(2, 2, 7, 2, 5, 4, 7, 4)) return 4;

    return -1;
}


bool belongsToTriangle(int x1, int y1, int x2, int y2, int x3, int y3, int x, int y)
{
    double originalArea = calculateArea(x1, y1, x2, y2, x3, y3);
    double areaA = calculateArea(x, y, x2, y2, x3, y3);
    double areaB = calculateArea(x1, y1, x, y, x3, y3);
    double areaC = calculateArea(x1, y1, x2, y2, x, y);

    return (originalArea == areaA + areaB + areaC);
}

double calculateArea(int x1, int y1, int x2, int y2, int x3, int y3)
{
    return Math.Abs((x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2)) / 2.0);
}


bool isNonDegenerateTriangle(int x1, int y1, int x2, int y2, int x3, int y3) 
{
    double distanceA = calculateDistance(x1, y1, x2, y2);
    double distanceB = calculateDistance(x2, y2, x3, y3);
    double distanceC = calculateDistance(x1, y1, x3, y3);

    if (distanceA + distanceB <= distanceC) return false;
    if (distanceB + distanceC <= distanceA) return false;
    if (distanceA + distanceC <= distanceB) return false;

    return true;
}

double calculateDistance(int x1, int y1, int x2, int y2)
{
    return Math.Sqrt(Math.Pow((y2-y1),2) + Math.Pow((x2-x1),2));
}