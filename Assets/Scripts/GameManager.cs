using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int gridSize = 4; // 게임판의 크기
    public int targetValue = 2048; // 게임의 목표 값
    public GameObject tilePrefab; // 타일 프리팹
    public GameObject gameOverPanel; // 게임 오버 패널
    public Text scoreText; // 스코어를 표시할 텍스트
    public Text highScoreText; // 최고 점수를 표시할 텍스트
    private AudioSource audioSource;
    public AudioClip mergeClip; // 타일 병합 소리
    public AudioClip moveClip; // 타일 이동 소리

    private Tile[,] tiles; // 타일을 저장할 이차원 배열
    public float tileSize;
    private List<Tile> emptyTiles; // 빈 타일을 저장할 리스트
    private int score = 0; // 현재 스코어
    private int highScore = 0; // 최고 점수
    private bool isGameOver = false; // 게임 오버 여부

    // Start 함수에서 게임을 초기화합니다.
    void Start()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
        tiles = new Tile[gridSize, gridSize];
        emptyTiles = new List<Tile>();
        InitializeTiles();
        SpawnTile();
        SpawnTile();
        UpdateScore();
    }

    // 게임 오버 조건을 검사합니다.
    void Update()
    {
        if (!isGameOver) {
            if (emptyTiles.Count == 0 && !CanMergeTiles()) {
                isGameOver = true;
                ShowGameOverPanel();
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            MoveTilesLeft();
        } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            MoveTilesRight();
        } else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            //MoveTilesUp();
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            //MoveTilesDown();
        }
    }

     void MoveTilesLeft()
    {
        bool moved = false;
        for (int y = 0; y < gridSize; y++) {
            for (int x = 1; x < gridSize; x++) {
                if (tiles[x, y] != null) {
                    int newX = x;
                    while (newX > 0 && tiles[newX - 1, y] == null) {
                        newX--;
                    }
                    if (newX != x) {
                        Tile tile = tiles[x, y];
                        tiles[x, y] = null;
                        tiles[newX, y] = tile;
                        tile.x = newX;
                        tile.transform.position = new Vector3(newX * tileSize, y * tileSize, 0);
                        moved = true;
                    } else if (tiles[newX - 1, y] != null && tiles[newX - 1, y].number == tiles[x, y].number) {
                        Tile tile1 = tiles[x, y];
                        Tile tile2 = tiles[newX - 1, y];
                        tiles[x, y] = null;
                        tiles[newX - 1, y] = tile1;
                        tile1.x = newX - 1;
                        tile1.y = y;
                        tile1.SetNumber(tile1.number * 2);
                        Destroy(tile2.gameObject);
                        moved = true;
                        }
            }
        }
    }
    if (moved) {
        SpawnRandomTile();
    }
}

    void MoveTilesRight()
{
    bool moved = false;
    for (int y = 0; y < gridSize; y++) {
        for (int x = gridSize - 2; x >= 0; x--) {
            if (tiles[x, y] != null) {
                int newX = x;
                while (newX < gridSize - 1 && tiles[newX + 1, y] == null) {
                    newX++;
                }
                if (newX != x) {
                    Tile tile = tiles[x, y];
                    tiles[x, y] = null;
                    tiles[newX, y] = tile;
                    tile.x = newX;
                    tile.transform.position = new Vector3(newX * tileSize, y * tileSize, 0);
                    moved = true;
                } else if (tiles[newX + 1, y] != null && tiles[newX + 1, y].number == tiles[x, y].number) {
                    Tile tile1 = tiles[x, y];
                    Tile tile2 = tiles[newX + 1, y];
                    tiles[x, y] = null;
                    tiles[newX + 1, y] = tile1;
                    tile1.x = newX + 1;
                    tile1.y = y;
                    tile1.SetNumber(tile1.number * 2);
                    Destroy(tile2.gameObject);
                    moved = true;
                }
            }
        }
    }
    if (moved) {
        SpawnRandomTile();
    }
}




 void SpawnRandomTile()
    {
        Tile emptyTile = GetRandomEmptyTile();
        if (emptyTile != null) {
            GameObject tile = Instantiate(tilePrefab, emptyTile.transform.position, Quaternion.identity);
            Tile tileComponent = tile.GetComponent<Tile>();
            tileComponent.x = emptyTile.x;
            tileComponent.y = emptyTile.y;
            tileComponent.SetNumber(Random.value < 0.9f ? 2 : 4);
            tiles[tileComponent.x, tileComponent.y] = tileComponent;
        }
    }

    Tile GetRandomEmptyTile()
    {
        System.Collections.Generic.List<Tile> emptyTiles = new System.Collections.Generic.List<Tile>();
        for (int x = 0; x < gridSize; x++) {
            for (int y = 0; y < gridSize; y++) {
                if (tiles[x, y] == null) {
                    emptyTiles.Add(new Tile { x = x, y = y });
                }
            }
        }
        if (emptyTiles.Count > 0) {
            return emptyTiles[Random.Range(0, emptyTiles.Count)];
        } else {
            return null;
        }
    }

    // 게임판의 모든 타일을 초기화합니다.
    void InitializeTiles()
    {
        for (int x = 0; x < gridSize; x++) {
            for (int y = 0; y < gridSize; y++) {
                Vector2 position = new Vector2(x - (gridSize - 1) * 0.5f, y - (gridSize - 1) * 0.5f);
                GameObject tileObject = Instantiate(tilePrefab, position, Quaternion.identity, transform);
                Tile tile = tileObject.GetComponent<Tile>();
                tile.SetPosition(x, y);
                tiles[x, y] = tile;
                emptyTiles.Add(tile);
            }
        }
    }

    // 빈 타일 중 하나를 무작위로 선택하여 타일을 생성합니다.
    void SpawnTile()
    {
        if (emptyTiles.Count > 0) {
            Tile tile = emptyTiles[Random.Range(0, emptyTiles.Count)];
            tile.SetNumber(Random.value < 0.9f ? 2 : 4);
            emptyTiles.Remove(tile);
            PlaySound(moveClip);
        }
    }


// 타일을 병합할 수 있는지 검사합니다.
bool CanMergeTiles()
{
    for (int i = 0; i < gridSize; i++) {
        for (int j = 0; j < gridSize; j++) {
            Tile currentTile = tiles[i, j];
            if (currentTile != null) {
                Tile leftTile = GetNextTile(currentTile, Vector2.left);
                Tile rightTile = GetNextTile(currentTile, Vector2.right);
                Tile upTile = GetNextTile(currentTile, Vector2.up);
                Tile downTile = GetNextTile(currentTile, Vector2.down);
                if ((leftTile != null && currentTile.CanMergeWith(leftTile)) ||
                    (rightTile != null && currentTile.CanMergeWith(rightTile)) ||
                    (upTile != null && currentTile.CanMergeWith(upTile)) ||
                    (downTile != null && currentTile.CanMergeWith(downTile))) {
                        return true;
                    }
                }
            }
        }
    return false;
}

// 주어진 타일과 이동 방향에 대해 다음 타일을 반환합니다.
Tile GetNextTile(Tile currentTile, Vector2 direction)
{
    int x = Mathf.RoundToInt(currentTile.transform.localPosition.x / tileSize);
    int y = Mathf.RoundToInt(currentTile.transform.localPosition.y / tileSize);
    while (true) {
        x += Mathf.RoundToInt(direction.x);
        y += Mathf.RoundToInt(direction.y);
        if (x < 0 || x >= gridSize || y < 0 || y >= gridSize) {
            return null;
        }
        Tile nextTile = tiles[x, y];
        if (nextTile != null) {
            return nextTile;
        }
    }
}


// 게임오버 패널을 보여줍니다.
void ShowGameOverPanel()
{
    gameOverPanel.SetActive(true);
    scoreText.text = "Score: " + score;
    highScoreText.text = "High Score: " + highScore;
}

// 점수를 업데이트합니다.
void UpdateScore()
{
    scoreText.text = "Score: " + score;
    if (score > highScore) {
        highScore = score;
        PlayerPrefs.SetInt("HighScore", highScore);
    }
    highScoreText.text = "High Score: " + highScore;
}

// 사운드를 재생합니다.
void PlaySound(AudioClip clip)
{
    audioSource.PlayOneShot(clip);
}
}
