# Alone in Space

[Android download link](https://play.google.com/store/apps/details?id=com.DefaultCompany.Endless_Game_1) <br><br>
[Gameplay video](https://youtu.be/4l-NsfY4w0o) |
[Store video](https://youtu.be/dAy0mjT7q4o) |
[Notify video](https://youtu.be/8Yq9a1YovLE) <br><br>

This project was generated with Unity 2018.4.36f1.

This is a hyper casual game for android platform. Collect coin and don't hit red bad boys

## Design patterns used in this project
* [Singleton](#Singleton)
* [Object Pool](#Object-Pool)
* [Observer (C# Delegate)](#Observer)
* [State (Class-based)](#State)
* [Subclass sandbox](#Subclass-sandbox)

## Concepts used in this project
* [Coroutine](#Coroutine)
* [Basic animation](#Basic-animation)
* [Particle effects](#Particle-effects)


## Design Patterns


### Singleton
Basic usage of singleton. I don't need to transfer data between scenes. So i don't use <code>DontDestroyOnLoad</code>. <br>
Singleton.cs:
```c#
protected virtual void Awake()
{
  Init();
}

private void Init()
{
  if (Instance == null || Instance.Equals(null))
    Instance = this as T;
  else if (Instance != this as T)
    Destroy(gameObject);
}
```


### Object Pool
Spawner.cs:
```c#
private void Start()
{
  StartCoroutine(CreateObjectPool()); // Creating on start because i want to objects load before game session. 
}

private void Update()
{
  if (isCreatingContinue) return;
  if (patterns[currentPattern].IsShowing()) return;

  // Select a new pattern and repeat if this pattern is the same as the previous one.
  // Otherwise, if the same pattern appears, the pattern is repositioned without leaving the screen completely.
  // This is an undesirable situation. 
  int newPattern;
  do
  {
    newPattern = PickRandomPattern(); // Returns negative if the number of objects is insufficient  
    if (newPattern < 0)
      return;
  } while (newPattern == currentPattern);
  currentPattern = newPattern;

  //Some codes
}

private IEnumerator CreateObjectPool()
{
  // Instantiate objects
}
```


### Observer
A delegate is defined in the subject. Observers add themselves to this delegate when enabled and delete themselves from this delegate when disabled.<br>
Subject:
```c#
public delegate void OnCoinChange(int coin);
public OnCoinChange TempCoinChanged;

public void AddToTempCoin(int amount)
{
  // Some codes
  TempCoinChanged?.Invoke(tempCoin);
}
```
Observer:
```c#
protected override void OnEnable()
{
  // Some codes
  coinController.TempCoinChanged += UpdateText;
}

private void OnDisable()
{
  // Some codes
  coinController.TempCoinChanged -= UpdateText;
}
```


### State
GameBaseState.cs:
```c#
public abstract void EnterState(GameStateController stateController);
public abstract void Update(GameStateController stateController);
```
GameStateController:
```c#
private GameBaseState CurrentState { get; set; }

public readonly GamePlayState PlayState = new GamePlayState();
public readonly GamePauseState PauseState = new GamePauseState();
public readonly GameOverState OverState = new GameOverState();

private void Update()
{
  CurrentState.Update(this);
}
    
public void TransitionToState(GameBaseState newState)
{
  CurrentState = newState;
  CurrentState.EnterState(this);
}
```


### Subclass Sandbox
ThemeApplier.cs:
```c#
protected virtual void SetTheme()
{
  // Empty function
}
```
ThemeApplierImage.cs (child of ThemeApplier):
```c#
protected override void SetTheme()
{
  // ThemeApplierImage specific codes
}
```
ThemeApplierSpriteRenderer.cs (child of ThemeApplier):
```c#
protected override void SetTheme()
{
  // ThemeApplierSpriteRenderer specific codes
}
```

## Concepts

### Coroutines 
Used to [basic animation](#Basic-animation) and create [object pool](#Object-Pool) objects

### Basic animation
Used for x2 score boost. <br>
CharacterMovement.cs:
```c#
private void OnTriggerEnter2D(Collider2D collision)
{
  if (collision.CompareTag("DoubleCoin"))
  {
    StartCoroutine(DoubleScored());
  }
  // Some codes
}

private IEnumerator DoubleScored()
{
  animator.SetTrigger("blue");
  // Some codes and wait for sometime 
  animator.SetTrigger("white");
}
```

### Particle effects
Shape.cs:
```c#
[SerializeField] private GameObject particleEffect;
    
protected virtual void OnTriggerEnter2D(Collider2D collision)
{
  // Some codes
  Destroy(Instantiate(particleEffect, transform.position, Quaternion.identity), 1f);
}
```
