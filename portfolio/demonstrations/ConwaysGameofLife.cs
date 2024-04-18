namespace Conway;


public class Game {

    private int[,] _grid;

    private int _width;
    private int _height;


    public Game(int width, int height) {
        _width = width;
        _height = height;
        _grid = new int [width, height];

        Random rnd = new Random();

        for(int x = 0; x < width; x++) {
            for(int y = 0; y < height; y++) {
                _grid[x, y] = rnd.Next(0, 2);
            }
        }
    }


    public void Step() {
        var targets = new List<(int, int, int)>();

        for(int x = 0; x < _width; x++) {
            for(int y = 0; y < _height; y++) {
                switch (_grid[x, y]) {
                    case 0:
                        if (CountNeighbors(x, y) == 3) {
                            targets.Add((x, y, 1));
                        }
                        break;
                    
                    case 1:
                        int count = CountNeighbors(x, y);

                        if (count > 3 || count < 2) {
                            targets.Add((x, y, 0));
                        }
                        break;
                }
            }
        }

        foreach (var target in targets) {
            _grid[target.Item1, target.Item2] = target.Item3;
        }
    }


    public void Output() {
        String display = "";

        for(int x = 0; x < _width; x++) {
            for(int y = 0; y < _height; y++) {
                switch (_grid[x, y]) {
                    case 0:
                        display = display + " ";
                        break;  

                    case 1:
                        display = display + "#";
                        break;

                    default:
                        break;
                }
            }

            display = display + "\n";
        }

        Console.WriteLine(display);
    }


    public int CountNeighbors(int x, int y) {
        int result = -_grid[x, y];

        for(int offset_x = -1; offset_x < 2; offset_x++) {
            for (int offset_y = -1; offset_y < 2; offset_y++) { 
                (int, int) target = wrap_index(x + offset_x, y + offset_y);
                result += _grid[target.Item1, target.Item2];
            }
        }

        return result;
    }


    private (int, int) wrap_index(int x, int y) {
        (int, int) result = (x, y);

        if (x < 0) { result.Item1 = _width - 1; }
        if (y < 0) { result.Item2 = _height - 1; }

        if (x > _width - 1) { result.Item1 = 0; }
        if (y > _height - 1) { result.Item2 = 0; }

        return result;
    }
}