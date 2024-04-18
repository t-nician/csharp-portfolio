namespace Conway;

enum CellState {
    Alive,
    Dead
}

public class Game {

    private CellState[,] _grid;

    private int _width;
    private int _height;


    public Game(int width, int height) {
        _width = width;
        _height = height;
        _grid = new CellState [width, height];

        Random rnd = new Random();

        for(int x = 0; x < width; x++) {
            for(int y = 0; y < height; y++) {
                switch (rnd.Next(0, 2)) {
                    case 0:
                        _grid[x, y] = CellState.Dead;
                        break;
                    
                    case 1:
                        _grid[x, y] = CellState.Alive;
                        break;
                }
            }
        }
    }


    public void Loop(int delay_miliseconds) {
        while (true) {
            Step();
            Output();

            Thread.Sleep(delay_miliseconds);
        }
    }


    public void Step() {
        var targets = new List<(int, int, CellState)>();

        for(int x = 0; x < _width; x++) {
            for(int y = 0; y < _height; y++) {
                switch (_grid[x, y]) {
                    case CellState.Dead:
                        if (CountNeighbors(x, y) == 3) {
                            targets.Add((x, y, CellState.Alive));
                        }
                        break;
                    
                    case CellState.Alive:
                        int count = CountNeighbors(x, y);

                        if (count > 3 || count < 2) {
                            targets.Add((x, y, CellState.Dead));
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
        string display = "";

        for(int x = 0; x < _width; x++) {
            for(int y = 0; y < _height; y++) {
                switch (_grid[x, y]) {
                    case CellState.Dead:
                        display = display + " ";
                        break;  

                    case CellState.Alive:
                        display = display + "#";
                        break;

                    default:
                        break;
                }
            }

            display = display + "\n";
        }

        Console.Clear();
        Console.WriteLine(display);
    }


    public int CountNeighbors(int x, int y) {
        int result = 0; //

        if (_grid[x, y] == CellState.Alive) {
            result -= 1;
        }

        for(int offset_x = -1; offset_x < 2; offset_x++) {
            for (int offset_y = -1; offset_y < 2; offset_y++) { 
                (int, int) target = WrapIndex(x + offset_x, y + offset_y);

                if (_grid[target.Item1, target.Item2] == CellState.Alive) {
                    result += 1;
                }
            }
        }

        return result;
    }


    private (int, int) WrapIndex(int x, int y) {
        (int, int) result = (x, y);

        if (x < 0) { result.Item1 = _width - 1; }
        if (y < 0) { result.Item2 = _height - 1; }

        if (x > _width - 1) { result.Item1 = 0; }
        if (y > _height - 1) { result.Item2 = 0; }

        return result;
    }
}