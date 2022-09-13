# mazegen-api

MazeGen is an API to generate mazes on a grid of ASCII characters! The backend is hosted in Azure App Service and the API itself is managed by Azure API Management.

**Note: URLs must be encoded in order for the API to work as intended.**

### The hosted API is currently down. You can clone this repo and open the `.sln` file in Visual Studio to test it locally.

---

## Examples

### A maze using default settings

`/api/maze`

```json
{
  "contents": [
    "         #   # #   # ",
    "#### ####### # # ### ",
    " #   # # #   #   #   ",
    " ### # # ### # ##### ",
    "       # #   #   # # ",
    "## # ### ### ### # # ",
    "   #   #     # # # # ",
    " ### ##### ### # # # ",
    " #     #     #       ",
    " # # ####### ### # ##",
    " # #   # #       #   ",
    "###### # ### # ### ##",
    "     #   #   #   #   ",
    "#### # ### # ### # # ",
    "O# #       # #   # # ",
    " # ### ##### ##### ##",
    "   #   #     #      X",
    " # # ##### ### # # # ",
    " #     #   #   # # # ",
    "## # ##### # ##### # ",
    "   # #     # #     # "
  ],
  "corridorsX": 10,
  "corridorsY": 10,
  "algorithm": "Prim",
  "startSymbol": "O",
  "endSymbol": "X",
  "wallSymbol": "#",
  "floorSymbol": " "
}
```

### A maze with a set size

`/api/maze?corridorsX=5&corridorsY=5`

```json
{
  "contents": [
    "###########",
    "           ",
    "###### ####",
    "O        # ",
    "###### ### ",
    "           ",
    "#### ### #X",
    " #   #   # ",
    " # # # # ##",
    "   # # #   ",
    "###########"
  ],
  "corridorsX": 5,
  "corridorsY": 5,
  "algorithm": "Prim",
  "startSymbol": "O",
  "endSymbol": "X",
  "wallSymbol": "#",
  "floorSymbol": " "
}
```

### A maze with custom symbols

`/api/maze?corridorsX=19&corridorsY=6&algorithm=Prim&startSymbol=S&endSymbol=G&wallSymbol=%25&floorSymbol=.`

```json
{
  "contents": [
    ".%...........%...%.%...%...%.%.....%..G",
    ".%%%.%%%%%%%%%%%.%.%.%%%%%.%.%%%.%%%.%%",
    "...%...%.%.%...%...%...........%.......",
    ".%%%%%.%.%.%.%%%.%.%.%%%.%%%%%.%.%%%%%%",
    "...%.....%.......%...%.%.....%.........",
    ".%%%%%.%%%.%.%%%.%%%.%.%%%%%.%%%.%.%%%%",
    "S%...%.%.%.%...%...%.......%...%.%...%.",
    ".%%%.%.%.%.%%%%%%%.%%%.%.%%%.%%%%%%%%%.",
    ".%.........%.%...%...%.%.%.............",
    ".%%%%%.%%%%%.%.%%%.%%%%%.%%%%%.%%%%%%%%",
    ".%.............%.%.....%.%.......%.....",
    ".%.%.%%%.%%%%%.%.%.%.%.%%%%%%%%%.%.%.%%",
    "...%...%.....%...%.%.%.....%.......%..."
  ],
  "corridorsX": 19,
  "corridorsY": 6,
  "algorithm": "Prim",
  "startSymbol": "S",
  "endSymbol": "G",
  "wallSymbol": "%",
  "floorSymbol": "."
}
```

---

## Usage

**Endpoint:** `GET /api/maze`

**Parameters:**

| Endpoint      | Description                                                                                                         | Default Value  |
| ------------- | ------------------------------------------------------------------------------------------------------------------- | -------------- |
| `corridorsX`  | Sets the width of the maze. The number of characters for the length is equal to `2 * corridorsX + 1`. (Minimum: 1)  | 10             |
| `corridorsY`  | Sets the height of the maze. The number of characters for the length is equal to `2 * corridorsY + 1`. (Minimum: 1) | 10             |
| `algorithm`   | Sets the generation algorithm. Available algorithms: `Prim`, `DepthFirstSearch`                                     | `Prim`         |
| `startSymbol` | Sets the symbol representing the starting point of the maze.                                                        | `O`            |
| `endSymbol`   | Sets the symbol representing the goal of the maze.                                                                  | `X`            |
| `wallSymbol`  | Sets the symbol representing a wall.                                                                                | `#`            |
| `floorSymbol` | Sets the symbol representing the starting point of the maze. (Optional)                                             | `null` (Space) |
