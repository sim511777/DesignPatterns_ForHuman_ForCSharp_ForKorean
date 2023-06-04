<h3 align="center">
<a href="https://github.com/kamranahmedse/design-patterns-for-humans">인간을 위한 디자인 패턴</a>을 C#으로 조정
</h3>
<p align="center"><sub>디자인 패턴에 대한 모든 설명은 약간의 변경만 있을 뿐 동일하게 유지됩니다.</sub></p>

****

<p align="center">
🎉 디자인 패턴에 대한 초간단 설명! 🎉
</p>
<p align="center">
누구나 쉽게 마음을 동요시킬 수 있는 주제. 여기서는 가능한 <i>가장 간단한</i> 방법으로 설명함으로써 그것들이 당신의 마음(그리고 아마도 내 마음)에 각인되도록 노력합니다.
</p>
<p align="center">
이 문서에서 사용된 코드 스니펫의 전체 길이 예제는 <a href="https://github.com/anupavanm/csharp-design-patterns-for-humans-examples">여기에서 찾을 수 있습니다.</a>
</p>

****

<br>

|[Creational Design Patterns](#creational-design-patterns)|[Structural Design Patterns](#structural-design-patterns)|[Behavioral Design Patterns](#behavioral-design-patterns)|
|:-|:-|:-|
|[Simple Factory](#-simple-factory)|[Adapter](#-adapter)|[Chain of Responsibility](#-chain-of-responsibility)|
|[Factory Method](#-factory-method)|[Bridge](#-bridge)|[Command](#-command)|
|[Abstract Factory](#-abstract-factory)|[Composite](#-composite)|[Iterator](#-iterator)|
|[Builder](#-builder)|[Decorator](#-decorator)|[Mediator](#-mediator)|
|[Prototype](#-prototype)|[Facade](#-facade)|[Memento](#-memento)|
|[Singleton](#-singleton)|[Flyweight](#-flyweight)|[Observer](#-observer)|
||[Proxy](#-proxy)|[Visitor](#-visitor)|
|||[Strategy](#-strategy)|
|||[State](#-state)|
|||[Template Method](#-template-method)|

<br>

🚀 소개
=================

디자인 패턴은 반복되는 문제에 대한 해결책입니다. **특정 문제를 해결하는 방법에 대한 지침**. 응용 프로그램에 연결하고 마법이 일어나기를 기다릴 수 있는 클래스, 패키지 또는 라이브러리가 아닙니다. 오히려 특정 상황에서 특정 문제를 해결하는 방법에 대한 지침입니다.

> 디자인 패턴은 반복되는 문제에 대한 해결책입니다. 특정 문제를 해결하는 방법에 대한 지침

Wikipedia는 다음과 같이 설명합니다.

> 소프트웨어 엔지니어링에서 소프트웨어 디자인 패턴은 소프트웨어 디자인에서 주어진 컨텍스트 내에서 일반적으로 발생하는 문제에 대한 재사용 가능한 일반적인 솔루션입니다. 소스나 기계 ​​코드로 직접 변환할 수 있는 완성된 디자인이 아닙니다. 다양한 상황에서 사용할 수 있는 문제 해결 방법에 대한 설명 또는 템플릿입니다.

⚠️ 조심하세요
-----------------
- 디자인 패턴이 모든 문제에 대한 묘책은 아닙니다.
- 강제로 시도하지 마십시오. 그렇게 하면 나쁜 일이 일어나기로 되어 있습니다. 디자인 패턴은 문제를 **찾는** 솔루션이 아니라 문제 **에 대한** 솔루션이라는 점을 명심하십시오. 너무 생각하지 마십시오.
- 올바른 장소에 올바른 방법으로 사용하면 구원자가 될 수 있습니다. 그렇지 않으면 코드가 끔찍하게 엉망이 될 수 있습니다.

> 또한 아래 코드 샘플은 C#-7에 있지만 개념이 어쨌든 동일하기 때문에 이것이 중단되어서는 안 됩니다. 또한 **다른 언어에 대한 지원이 진행 중**입니다.

디자인 패턴의 종류
-----------------

* [Creational](#creational-design-patterns)
* [Structural](#structural-design-patterns)
* [Behavioral](#behavioral-design-patterns)

Creational Design Patterns
==========================

평범한 말로
> 생성 패턴은 개체 또는 관련 개체 그룹을 인스턴스화하는 방법에 중점을 둡니다.

위키백과 말한다
> 소프트웨어 엔지니어링에서 생성 디자인 패턴은 개체 생성 메커니즘을 다루는 디자인 패턴으로 상황에 적합한 방식으로 개체를 생성하려고 합니다. 개체 생성의 기본 형태는 디자인 문제를 일으키거나 디자인에 복잡성을 더할 수 있습니다. 생성 디자인 패턴은 이 객체 생성을 어떻게든 제어함으로써 이 문제를 해결합니다.

 * [Simple Factory](#-simple-factory)
 * [Factory Method](#-factory-method)
 * [Abstract Factory](#-abstract-factory)
 * [Builder](#-builder)
 * [Prototype](#-prototype)
 * [Singleton](#-singleton)

🏠 Simple Factory
--------------
실제 사례
> 당신이 집을 짓고 있고 문이 필요하다고 생각해 보십시오. 문이 필요할 때마다 목수 옷을 입고 집에 문을 만들기 시작하면 엉망이 될 것입니다. 대신 공장에서 만들어집니다.

평범한 말로
> 단순 팩토리는 인스턴스화 논리를 클라이언트에 노출하지 않고 단순히 클라이언트에 대한 인스턴스를 생성합니다.

위키백과 말한다
> 객체 지향 프로그래밍(OOP)에서 팩토리는 다른 객체를 생성하기 위한 객체입니다. 공식적으로 팩토리는 "new" 로 간주되는 일부 메서드 호출에서 다양한 프로토타입 또는 클래스의 객체를 반환하는 함수 또는 메서드입니다.

 **프로그래매틱 예시**

우선 도어 인터페이스와 구현이 있습니다.
```C#
public interface IDoor
{
    int GetHeight();
    int GetWidth();
}

public class WoodenDoor : IDoor
{
    private int Height { get; set; }
    private int Width { get; set; }

    public WoodenDoor(int height, int width)
    {
        this.Height = height;
        this.Width = width;
    }

    public int GetHeight()
    {
        return this.Height;
    }
    public int GetWidth()
    {
        return this.Width;
    }
}
```
그런 다음 문을 만들고 반환하는 문 공장이 있습니다.
```C#
public static class DoorFactory
{
    public static IDoor MakeDoor(int height, int width)
    {
        return new WoodenDoor(height, width);
    }
}
```
그런 다음 다음과 같이 사용할 수 있습니다.
```C#
var door = DoorFactory.MakeDoor(80, 30);
Console.WriteLine($"Height of Door : {door.GetHeight()}");
Console.WriteLine($"Width of Door : {door.GetWidth()}");
```

**언제 사용하나요?**

개체를 만드는 것이 단지 몇 가지 할당이 아니라 일부 논리를 포함하는 경우 모든 곳에서 동일한 코드를 반복하는 대신 전용 팩터리에 넣는 것이 좋습니다.

🏭 Factory Method
--------------

실제 사례
> 고용 관리자의 경우를 생각해 보십시오. 한 사람이 각 직책에 대해 인터뷰하는 것은 불가능합니다. 채용 공고에 따라 인터뷰 단계를 결정하고 다른 사람들에게 위임해야 합니다.

평범한 말로
> 하위 클래스에 인스턴스화 논리를 위임하는 방법을 제공합니다.

위키백과 말한다
> 클래스 기반 프로그래밍에서 팩토리 메소드 패턴은 생성될 객체의 정확한 클래스를 지정하지 않고도 객체 생성 문제를 처리하기 위해 팩토리 메소드를 사용하는 생성 패턴입니다. 이는 생성자를 호출하는 대신 인터페이스에 지정되고 자식 클래스에 의해 구현되거나 기본 클래스에 구현되고 선택적으로 파생 클래스에 의해 재정의되는 팩토리 메서드를 호출하여 객체를 생성함으로써 수행됩니다.

 **프로그래매틱 예시**

위의 고용 관리자 예를 들어 보겠습니다. 우선 면접관 인터페이스와 그에 대한 몇 가지 구현이 있습니다.

```C#
interface IInterviewer
{
    void AskQuestions();
}

class Developer : IInterviewer
{
    public void AskQuestions()
    {
        Console.WriteLine("Asking about design patterns!");
    }
}

class CommunityExecutive : IInterviewer
{
    public void AskQuestions()
    {
        Console.WriteLine("Asking about community building!");
    }
}
```

이제 `Hiring Manager`를 만들어 보겠습니다.

```C#
abstract class HiringManager
{
    // Factory method
    abstract protected IInterviewer MakeInterviewer();
    public void TakeInterview()
    {
        var interviewer = this.MakeInterviewer();
        interviewer.AskQuestions();
    }
}

```
이제 모든 파생 클래스가 이를 확장하고 필요한 면접관을 제공할 수 있습니다.
```C#
class DevelopmentManager : HiringManager
{
    protected override IInterviewer MakeInterviewer()
    {
        return new Developer();
    }
}

class MarketingManager : HiringManager
{
    protected override IInterviewer MakeInterviewer()
    {
        return new CommunityExecutive();
    }
}

```
그런 다음 다음과 같이 사용할 수 있습니다.

```C#
var devManager = new DevelopmentManager();
devManager.TakeInterview(); //Output : Asking about design patterns!

var marketingManager = new MarketingManager();
marketingManager.TakeInterview();//Output : Asking about community building!

```

**언제 사용하나요?**

클래스에 일부 일반 처리가 있지만 필요한 하위 클래스가 런타임에 동적으로 결정될 때 유용합니다. 또는 다른 말로 표현하면 클라이언트가 필요한 정확한 하위 클래스가 무엇인지 모를 때입니다.

🔨 Abstract Factory
----------------

실제 사례
> Simple Factory에서 도어 예제를 확장합니다. 필요에 따라 목제 문 상점에서 나무 문을, 철 상점에서 철문을, 관련 상점에서 PVC 문을 얻을 수 있습니다. 또한 문을 맞추려면 다른 종류의 전문 분야를 가진 사람이 필요할 수 있습니다. 예를 들어 나무 문을 위한 목수, 철문을 위한 용접공 등입니다. 지금 볼 수 있듯이 문 사이에 종속성이 있으므로 나무 문에는 목수, 철문이 필요합니다. 용접기 등이 필요합니다.

평범한 말로
> 공장 중의 공장 구체적인 클래스를 지정하지 않고 개별적이지만 관련/종속적인 팩토리를 함께 그룹화하는 팩토리.

위키백과 말한다
> 추상 팩토리 패턴은 구체적인 클래스를 지정하지 않고 공통 주제를 가진 개별 팩토리 그룹을 캡슐화하는 방법을 제공합니다.

**프로그래매틱 예시**

위의 문 예를 번역합니다. 우선 `Door` 인터페이스와 이에 대한 일부 구현이 있습니다.

```C#
interface IDoor {

  void GetDescription();

}
class WoodenDoor : IDoor
{
  public void GetDescription()
  {
    Console.WriteLine("I am a wooden door");
  }
}

class IronDoor : IDoor
{
  public void GetDescription()
  {
    Console.WriteLine("I am a iron door");
  }
}
```
그런 다음 각 도어 유형에 맞는 피팅 전문가가 있습니다.

```C#
interface IDoorFittingExpert
{
  void GetDescription();
}

class Welder : IDoorFittingExpert
{
  public void GetDescription()
  {
    Console.WriteLine("I can only fit iron doors");
  }
}

class Carpenter : IDoorFittingExpert
{
  public void GetDescription()
  {
    Console.WriteLine("I can only fit wooden doors");
  }
}
```

이제 우리는 관련 객체의 패밀리를 만들 수 있는 추상 공장을 가지고 있습니다. 즉, 나무 문 공장은 나무 문과 나무 문 부속품 전문가를 만들고 철문 공장은 철문과 철문 부속품 전문가를 만듭니다
```C#
interface IDoorFactory {
  IDoor MakeDoor();
  IDoorFittingExpert MakeFittingExpert();
}

// Wooden factory to return carpenter and wooden door
class WoodenDoorFactory : IDoorFactory
{
  public IDoor MakeDoor()
  {
    return new WoodenDoor();
  }

  public IDoorFittingExpert MakeFittingExpert()
  {
    return new Carpenter();
  }
}

// Iron door factory to get iron door and the relevant fitting expert
class IronDoorFactory : IDoorFactory
{
  public IDoor MakeDoor()
  {
    return new IronDoor();
  }

  public IDoorFittingExpert MakeFittingExpert()
  {
    return new Welder();
  }
}
```
그런 다음 다음과 같이 사용할 수 있습니다.
```C#
var woodenDoorFactory = new WoodenDoorFactory();

var woodenDoor = woodenDoorFactory.MakeDoor();
var woodenDoorFittingExpert = woodenDoorFactory.MakeFittingExpert();

woodenDoor.GetDescription(); //Output : I am a wooden door
woodenDoorFittingExpert.GetDescription();//Output : I can only fit woooden doors

var ironDoorFactory = new IronDoorFactory();

var ironDoor = ironDoorFactory.MakeDoor();
var ironDoorFittingExpert = ironDoorFactory.MakeFittingExpert();

ironDoor.GetDescription();//Output : I am a iron door
ironDoorFittingExpert.GetDescription();//Output : I can only fit iron doors
```

보시다시피 목수공장은 '목수'와 '목문'을 캡슐화했고, 철문공장은 '철문'과 '용접공'을 캡슐화했습니다. 따라서 생성된 각 문에 대해 잘못된 피팅 전문가를 얻지 않도록 하는 데 도움이 되었습니다.

**언제 사용하나요?**

그다지 단순하지 않은 생성 로직과 상호 관련된 종속성이 있는 경우

👷 Builder
--------------------------------------------
실제 사례
> 당신이 Hardee's에 있고 특정 거래를 주문한다고 상상해 보십시오. 이것은 간단한 공장의 예입니다. 그러나 생성 논리에 더 많은 단계가 포함될 수 있는 경우가 있습니다. 예를 들어 맞춤형 지하철 거래를 원하는 경우 햄버거를 만드는 방법에 대한 몇 가지 옵션이 있습니다(예: 어떤 빵을 원하십니까?). 어떤 종류의 소스를 원하십니까? 어떤 치즈를 원하세요? 등 이러한 경우 빌더 패턴이 구출됩니다.

평범한 말로
> 생성자 오염을 피하면서 개체의 다양한 특징을 만들 수 있습니다. 개체의 여러 가지 특징이 있을 수 있는 경우에 유용합니다. 또는 개체 생성에 관련된 많은 단계가 있는 경우.

위키백과 말한다
> 빌더 패턴은 텔레스코핑 생성자 안티 패턴에 대한 해결책을 찾기 위한 객체 생성 소프트웨어 디자인 패턴입니다.

Telescoping 생성자 안티 패턴이 무엇인지에 대해 조금 추가하겠습니다. 한 지점 또는 다른 지점에서 우리는 모두 아래와 같은 생성자를 보았습니다.

```C#
public Burger(int size, bool cheese, bool pepperoni, bool lettuce, bool tomato)
{
}
```

보시다시피; 생성자 매개변수의 수는 빠르게 감당할 수 없게 되고 매개변수의 배열을 이해하기 어려워질 수 있습니다. 또한 이 매개변수 목록은 나중에 더 많은 옵션을 추가하려는 경우 계속 커질 수 있습니다. 이를 텔레스코핑 생성자 안티패턴이라고 합니다.

**프로그래매틱 예시**

건전한 대안은 빌더 패턴을 사용하는 것입니다. 우선 우리가 만들고 싶은 햄버거가 있습니다.

```C#
class Burger
{
  private int mSize;
  private bool mCheese;
  private bool mPepperoni;
  private bool mLettuce;
  private bool mTomato;

  public Burger(BurgerBuilder builder)
  {
    this.mSize = builder.Size;
    this.mCheese = builder.Cheese;
    this.mPepperoni = builder.Pepperoni;
    this.mLettuce = builder.Lettuce;
    this.mTomato = builder.Tomato;
  }

  public string GetDescription()
  {
    var sb = new StringBuilder();
    sb.Append($"This is {this.mSize} inch Burger. ");
    return sb.ToString();
  }
}
```

그런 다음 빌더가 있습니다.

```C#
class BurgerBuilder {
  public int Size;
  public bool Cheese;
  public bool Pepperoni;
  public bool Lettuce;
  public bool Tomato;

  public BurgerBuilder(int size)
  {
    this.Size = size;
  }

  public BurgerBuilder AddCheese()
  {
    this.Cheese = true;
    return this;
  }

  public BurgerBuilder AddPepperoni()
  {
    this.Pepperoni = true;
    return this;
  }

  public BurgerBuilder AddLettuce()
  {
    this.Lettuce = true;
    return this;
  }

  public BurgerBuilder AddTomato()
  {
    this.Tomato = true;
    return this;
  }

  public Burger Build()
  {
    return new Burger(this);
  }
}
```
그런 다음 다음과 같이 사용할 수 있습니다.

```C#
var burger = new BurgerBuilder(4).AddCheese()
                                .AddPepperoni()
                                .AddLettuce()
                                .AddTomato()
                                .Build();
Console.WriteLine(burger.GetDescription());
```

**언제 사용하나요?**

개체의 여러 가지 특징이 있을 수 있고 생성자 텔레스코핑을 피하기 위해. 팩토리 패턴과의 주요 차이점은 다음과 같습니다. 팩토리 패턴은 생성이 한 단계 프로세스일 때 사용되며 빌더 패턴은 생성이 여러 단계 프로세스일 때 사용됩니다.

🐑 Prototype
------------
Real world example
> Remember dolly? The sheep that was cloned! Lets not get into the details but the key point here is that it is all about cloning

평범한 말로
> 복제를 통해 기존 개체를 기반으로 개체를 만듭니다.

위키백과 말한다
> 프로토타입 패턴은 소프트웨어 개발에서 창조적인 디자인 패턴입니다. 생성할 개체의 유형이 새 개체를 생성하기 위해 복제되는 프로토타입 인스턴스에 의해 결정될 때 사용됩니다.

즉, 처음부터 개체를 만들고 설정하는 수고를 겪는 대신 기존 개체의 복사본을 만들고 필요에 따라 수정할 수 있습니다.

**프로그래매틱 예시**

C#에서는 `Memberwise Clone()`을 사용하여 쉽게 수행할 수 있습니다.

```C#
class Sheep
{
  public string Name { get; set; }

  public string Category { get; set; }

  public Sheep(string name, string category)
  {
    Name = name;
    Category = category;
  }

  public Sheep Clone()
  {
    return MemberwiseClone() as Sheep;
  }
}
```
그런 다음 아래와 같이 복제할 수 있습니다.
```C#
var original = new Sheep("Jolly", "Mountain Sheep");
Console.WriteLine(original.Name); // Jolly
Console.WriteLine(original.Category); // Mountain Sheep

var cloned = original.Clone();
cloned.Name = "Dolly";
Console.WriteLine(cloned.Name); // Dolly
Console.WriteLine(cloned.Category); // Mountain Sheep
Console.WriteLine(original.Name); // Jolly
```

**언제 사용하나요?**

기존 객체와 유사한 객체가 필요하거나 복제에 비해 생성 비용이 많이 드는 경우.

💍 Singleton
------------
실제 사례
> 한 국가의 대통령은 한 번에 한 명만 있을 수 있습니다. 의무가 부를 때마다 같은 대통령이 행동에 나서야 합니다. 여기 대통령은 싱글 톤입니다.

평범한 말로
> 특정 클래스의 개체가 하나만 생성되도록 합니다.

위키백과 말한다
> 소프트웨어 엔지니어링에서 싱글톤 패턴은 클래스의 인스턴스화를 하나의 개체로 제한하는 소프트웨어 디자인 패턴입니다. 이는 시스템 전체에서 작업을 조정하는 데 정확히 하나의 개체가 필요한 경우에 유용합니다.

싱글톤 패턴은 실제로 안티 패턴으로 간주되며 이를 과도하게 사용하는 것은 피해야 합니다. 반드시 나쁜 것은 아니며 일부 유효한 사용 사례가 있을 수 있지만 응용 프로그램에 전역 상태를 도입하고 한 곳에서 변경하면 다른 영역에 영향을 미칠 수 있고 디버그하기가 매우 어려워질 수 있으므로 주의해서 사용해야 합니다. 그들에 대한 또 다른 나쁜 점은 코드를 단단히 결합시키고 싱글톤을 조롱하는 것이 어려울 수 있다는 것입니다.

**프로그래매틱 예시**

싱글톤을 만들려면 생성자를 비공개로 만들고, 복제를 비활성화하고, 확장을 비활성화하고 인스턴스를 보관할 정적 변수를 만듭니다.
```C#
public class President
{
  static President instance;
  // Private constructor
  private President()
  {
    //Hiding the Constructor
  }

  // Public constructor
  public static President GetInstance()
  {
    if (instance == null) {
      instance = new President();
    }
    return instance;
  }
}
```
그럼 사용을 위해
```C#
President a = President.GetInstance();
President b = President.GetInstance();

Console.WriteLine(a == b); //Output : true
```

Structural Design Patterns
==========================
평범한 말로
> 구조적 패턴은 주로 개체 구성, 즉 엔터티가 서로를 사용할 수 있는 방법과 관련이 있습니다. 또는 또 다른 설명은 "소프트웨어 구성 요소를 구축하는 방법"에 대답하는 데 도움이 된다는 것입니다.

위키백과 말한다
> 소프트웨어 엔지니어링에서 구조적 디자인 패턴은 엔터티 간의 관계를 구현하는 간단한 방법을 식별하여 디자인을 용이하게 하는 디자인 패턴입니다.

 * [Adapter](#-adapter)
 * [Bridge](#-bridge)
 * [Composite](#-composite)
 * [Decorator](#-decorator)
 * [Facade](#-facade)
 * [Flyweight](#-flyweight)
 * [Proxy](#-proxy)

🔌 Adapter
-------
실제 사례
> 메모리 카드에 몇 장의 사진이 있고 컴퓨터로 전송해야 한다고 생각하십시오. 메모리 카드를 전송하려면 컴퓨터에 메모리 카드를 연결할 수 있도록 컴퓨터 포트와 호환되는 일종의 어댑터가 필요합니다. 이 경우 카드 리더는 어댑터입니다.
> 또 다른 예는 유명한 전원 어댑터입니다. 3구 플러그는 2구 콘센트에 연결할 수 없으며 2구 콘센트와 호환되는 전원 어댑터를 사용해야 합니다.
> 또 다른 예는 한 사람이 다른 사람에게 말한 단어를 번역하는 번역가입니다.

평범한 말로
> 어댑터 패턴을 사용하면 호환되지 않는 개체를 어댑터로 래핑하여 다른 클래스와 호환되도록 할 수 있습니다.

위키백과 말한다
> 소프트웨어 엔지니어링에서 어댑터 패턴은 기존 클래스의 인터페이스를 또 다른 인터페이스로 사용할 수 있도록 하는 소프트웨어 설계 패턴입니다. 소스 코드를 수정하지 않고 기존 클래스가 다른 클래스와 함께 작동하도록 만드는 데 자주 사용됩니다.

**프로그래매틱 예시**

사냥꾼이 있고 사자를 사냥하는 게임을 생각해 보십시오.

먼저 모든 유형의 사자가 구현해야 하는 인터페이스 `Lion`이 있습니다.

```C#
interface ILion
{
  void Roar();
}

class AfricanLion : ILion
{
  public void Roar()
  {

  }
}

class AsiaLion : ILion
{
  public void Roar()
  {

  }
}
```
그리고 Hunter는 `Lion` 인터페이스의 구현이 사냥을 기대합니다.
```C#
class Hunter
{
  public void Hunt(ILion lion)
  {

  }
}
```

이제 사냥꾼이 사냥할 수 있도록 게임에 'Wild Dog'를 추가해야 한다고 가정해 보겠습니다. 하지만 dog는 인터페이스가 다르기 때문에 직접 할 수는 없습니다. 헌터와 호환되도록 하려면 호환되는 어댑터를 만들어야 합니다.

```C#
// This needs to be added to the game
class WildDog
{
  public void bark()
  {
  }
}

// Adapter around wild dog to make it compatible with our game
class WildDogAdapter : ILion
{
  private WildDog mDog;
  public WildDogAdapter(WildDog dog)
  {
    this.mDog = dog;
  }
  public void Roar()
  {
    mDog.bark();
  }
}
```
이제 `Wild Dog`는 `Wild Dog Adapter`를 사용하여 게임에서 사용할 수 있습니다.

```C#
var wildDog = new WildDog();
var wildDogAdapter = new WildDogAdapter(wildDog);

var hunter = new Hunter();
hunter.Hunt(wildDogAdapter);
```

🚡 Bridge
------
실제 사례
> 다른 페이지가 있는 웹사이트가 있고 사용자가 테마를 변경할 수 있도록 허용해야 한다고 가정합니다. 어떻게 하시겠습니까? 각 테마에 대해 각 페이지의 여러 복사본을 만들거나 별도의 테마를 만들고 사용자의 기본 설정에 따라 로드하시겠습니까? 브리지 패턴을 사용하면 두 번째 즉,

![With and without the bridge pattern](https://cloud.githubusercontent.com/assets/11269635/23065293/33b7aea0-f515-11e6-983f-98823c9845ee.png)

평범한 말로
> 브리지 패턴은 상속보다 구성을 선호하는 것입니다. 구현 세부 정보는 계층에서 별도의 계층이 있는 다른 개체로 푸시됩니다.

위키백과 말한다
> 브리지 패턴은 소프트웨어 엔지니어링에서 사용되는 디자인 패턴으로 "추상화를 구현에서 분리하여 둘이 독립적으로 변경될 수 있도록" 합니다.

**프로그래매틱 예시**

위의 웹 페이지 예제를 번역합니다. 여기에 '웹 페이지' 계층 구조가 있습니다.

```C#
interface IWebPage
{
  string GetContent();
}

class About : IWebPage
{
  protected ITheme theme;

  public About(ITheme theme)
  {
    this.theme = theme;
  }

  public string GetContent()
  {
    return $"About page in {theme.GetColor()}";
  }
}

class Careers : IWebPage
{
  protected ITheme theme;

  public Careers(ITheme theme)
  {
    this.theme = theme;
  }

  public string GetContent()
  {
    return $"Careers page in {theme.GetColor()}";
  }
}
```
그리고 별도의 테마 계층 구조
```C#

interface ITheme
{
  string GetColor();
}

class DarkTheme : ITheme
{
  public string GetColor()
  {
    return "Dark Black";
  }
}

class LightTheme : ITheme
{
  public string GetColor()
  {
    return "Off White";
  }
}

class AquaTheme : ITheme
{
  public string GetColor()
  {
    return "Light blue";
  }
}
```
그리고 두 계층 모두
```C#
var darkTheme = new DarkTheme();
var lightTheme = new LightTheme();

var about= new About(darkTheme);
var careers = new Careers(lightTheme);

Console.WriteLine(about.GetContent()); //Output: About page in Dark Black
Console.WriteLine(careers.GetContent()); //Output: Careers page in Off White
```

🌿 Composite
-----------------

실제 사례
> 모든 조직은 직원으로 구성됩니다. 각 직원은 동일한 기능을 가지고 있습니다. 즉, 급여가 있고, 책임이 있고, 누군가에게 보고할 수도 있고 하지 않을 수도 있고, 부하 직원이 있을 수도 있고 없을 수도 있습니다.

평범한 말로
> 복합 패턴을 통해 클라이언트는 개별 개체를 균일한 방식으로 처리할 수 있습니다.

위키백과 말한다
> 소프트웨어 엔지니어링에서 복합 패턴은 분할 디자인 패턴입니다. 복합 패턴은 개체 그룹이 개체의 단일 인스턴스와 동일한 방식으로 처리됨을 설명합니다. 복합의 의도는 개체를 트리 구조로 "구성"하여 부분-전체 계층을 나타내는 것입니다. 복합 패턴을 구현하면 클라이언트가 개별 개체와 구성을 균일하게 처리할 수 있습니다.

**프로그래매틱 예시**

위에서 직원을 예로 들어 보겠습니다. 여기에 다양한 직원 유형이 있습니다.

```C#
interface IEmployee
{
  float GetSalary();
  string GetRole();
  string GetName();
}


class Developer : IEmployee
{
  private string mName;
  private float mSalary;

  public Developer(string name, float salary)
  {
    this.mName = name;
    this.mSalary = salary;
  }

  public float GetSalary()
  {
    return this.mSalary;
  }

  public string GetRole()
  {
    return "Developer";
  }

  public string GetName()
  {
    return this.mName;
  }
}

class Designer : IEmployee
{
  private string mName;
  private float mSalary;

  public Designer(string name, float salary)
  {
    this.mName = name;
    this.mSalary = salary;
  }

  public float GetSalary()
  {
    return this.mSalary;
  }

  public string GetRole()
  {
    return "Designer";
  }

  public string GetName()
  {
    return this.mName;
  }
}
```

그런 다음 여러 유형의 직원으로 구성된 조직이 있습니다.

```C#
class Organization
{
  protected List<IEmployee> employees;

  public Organization()
  {
    employees = new List<IEmployee>();
  }

  public void AddEmployee(IEmployee employee)
  {
    employees.Add(employee);
  }

  public float GetNetSalaries()
  {
    float netSalary = 0;

    foreach (var e in employees) {
      netSalary += e.GetSalary();
    }
    return netSalary;
  }
}
```

그런 다음 다음과 같이 사용할 수 있습니다.

```C#
//Arrange Employees, Organization and add employees
var developer = new Developer("John", 5000);
var designer = new Designer("Arya", 5000);

var organization = new Organization();
organization.AddEmployee(developer);
organization.AddEmployee(designer);

Console.WriteLine($"Net Salary of Employees in Organization is {organization.GetNetSalaries():c}");
//Ouptut: Net Salary of Employees in Organization is $10000.00
```

☕ Decorator
-------------

실제 사례

> 여러 서비스를 제공하는 자동차 정비소를 운영한다고 상상해 보십시오. 이제 청구할 청구서를 어떻게 계산합니까? 하나의 서비스를 선택하고 최종 비용을 얻을 때까지 제공된 서비스에 대한 가격을 동적으로 계속 추가합니다. 여기서 각 유형의 서비스는 데코레이터입니다.

평범한 말로
> 데코레이터 패턴을 사용하면 데코레이터 클래스의 개체에 개체를 래핑하여 런타임에 개체의 동작을 동적으로 변경할 수 있습니다.

위키백과 말한다
> 개체 지향 프로그래밍에서 데코레이터 패턴은 동일한 클래스의 다른 개체의 동작에 영향을 주지 않고 정적 또는 동적으로 개별 개체에 동작을 추가할 수 있도록 하는 디자인 패턴입니다. 데코레이터 패턴은 단일 책임 원칙을 준수하는 데 유용한 경우가 많습니다. 고유한 관심 영역이 있는 클래스 간에 기능을 나눌 수 있기 때문입니다.

**프로그래매틱 예시**

예를 들어 커피를 보자. 먼저 커피 인터페이스를 구현하는 간단한 커피가 있습니다.

```C#
interface ICoffee
{
  int GetCost();
  string GetDescription();
}

class SimpleCoffee : ICoffee
{
  public int GetCost()
  {
    return 5;
  }

  public string GetDescription()
  {
    return "Simple Coffee";
  }
}
```
필요한 경우 옵션에서 코드를 수정할 수 있도록 코드를 확장 가능하게 만들고 싶습니다. 추가 기능(데코레이터)을 만들어 보겠습니다.
```C#
class MilkCoffee : ICoffee
{
  private readonly ICoffee mCoffee;

  public MilkCoffee(ICoffee coffee)
  {
    mCoffee = coffee ?? throw new ArgumentNullException("coffee", "coffee should not be null");
  }
  public int GetCost()
  {
    return mCoffee.GetCost() + 1;
  }

  public string GetDescription()
  {
    return String.Concat(mCoffee.GetDescription(), ", milk");
  }
}

class WhipCoffee : ICoffee
{
  private readonly ICoffee mCoffee;

  public WhipCoffee(ICoffee coffee)
  {
    mCoffee = coffee ?? throw new ArgumentNullException("coffee", "coffee should not be null");
  }
  public int GetCost()
  {
    return mCoffee.GetCost() + 1;
  }

  public string GetDescription()
  {
    return String.Concat(mCoffee.GetDescription(), ", whip");
  }
}

class VanillaCoffee : ICoffee
{
  private readonly ICoffee mCoffee;

  public VanillaCoffee(ICoffee coffee)
  {
    mCoffee = coffee ?? throw new ArgumentNullException("coffee", "coffee should not be null");
  }
  public int GetCost()
  {
    return mCoffee.GetCost() + 1;
  }

  public string GetDescription()
  {
    return String.Concat(mCoffee.GetDescription(), ", vanilla");
  }
}

```

이제 커피를 만들자

```C#
var myCoffee = new SimpleCoffee();
Console.WriteLine($"{myCoffee.GetCost():c}"); // $ 5.00
Console.WriteLine(myCoffee.GetDescription()); // Simple Coffee

var milkCoffee = new MilkCoffee(myCoffee);
Console.WriteLine($"{milkCoffee.GetCost():c}"); // $ 6.00
Console.WriteLine(milkCoffee.GetDescription()); // Simple Coffee, milk

var whipCoffee = new WhipCoffee(milkCoffee);
Console.WriteLine($"{whipCoffee.GetCost():c}"); // $ 7.00
Console.WriteLine(whipCoffee.GetDescription()); // Simple Coffee, milk, whip

var vanillaCoffee = new VanillaCoffee(whipCoffee);
Console.WriteLine($"{vanillaCoffee.GetCost():c}"); // $ 8.00
Console.WriteLine(vanillaCoffee.GetDescription()); // Simple Coffee, milk, whip, vanilla
```

📦 Facade
----------------

실제 사례
> 컴퓨터는 어떻게 켜나요? "전원 버튼을 누르세요"라고 말하세요! 그것은 컴퓨터가 외부에서 제공하는 간단한 인터페이스를 사용하고 있기 때문에 내부적으로는 많은 작업을 수행해야 하기 때문에 그렇게 믿는 것입니다. 복잡한 하위 시스템에 대한 이 간단한 인터페이스는 파사드입니다.

평범한 말로
> Facade 패턴은 복잡한 하위 시스템에 대한 단순화된 인터페이스를 제공합니다.

위키백과 말한다
> 파사드는 클래스 라이브러리와 같은 더 큰 코드 본문에 대한 단순화된 인터페이스를 제공하는 개체입니다.

**프로그래매틱 예시**

위의 컴퓨터 예를 들어 보겠습니다. 여기 컴퓨터 수업이 있어요

```C#
class Computer
{
  public void GetElectricShock()
  {
    Console.Write("Ouch!");
  }

  public void MakeSound()
  {
    Console.Write("Beep beep!");
  }

  public void ShowLoadingScreen()
  {
    Console.Write("Loading..");
  }

  public void Bam()
  {
    Console.Write("Ready to be used!");
  }

  public void CloseEverything()
  {
    Console.Write("Bup bup bup buzzzz!");
  }

  public void Sooth()
  {
    Console.Write("Zzzzz");
  }

  public void PullCurrent()
  {
    Console.Write("Haaah!");
  }
}
```
여기 우리는 정면이 있습니다
```C#
class ComputerFacade
{
  private readonly Computer mComputer;

  public ComputerFacade(Computer computer)
  {
    this.mComputer = computer ?? throw new ArgumentNullException("computer", "computer cannot be null");
  }

  public void TurnOn()
  {
    mComputer.GetElectricShock();
    mComputer.MakeSound();
    mComputer.ShowLoadingScreen();
    mComputer.Bam();
  }

  public void TurnOff()
  {
    mComputer.CloseEverything();
    mComputer.PullCurrent();
    mComputer.Sooth();
  }
}
```
이제 파사드를 사용하려면
```C#
var computer = new ComputerFacade(new Computer());
computer.TurnOn(); // Ouch! Beep beep! Loading.. Ready to be used!
Console.WriteLine();
computer.TurnOff();  // Bup bup buzzz! Haah! Zzzzz
Console.ReadLine();
```

🍃 Flyweight
---------

실제 사례
> 노점에서 신선한 차를 마신 적이 있습니까? 그들은 종종 당신이 요구한 하나 이상의 컵을 만들고 다른 고객을 위해 나머지는 저장하여 자원을 절약합니다. 가스 등 플라이급 패턴은 공유에 관한 것입니다.

평범한 말로
> 유사 객체와 최대한 공유하여 메모리 사용량이나 계산 비용을 최소화하기 위해 사용합니다.

위키백과 말한다
> 컴퓨터 프로그래밍에서 플라이웨이트는 소프트웨어 설계 패턴입니다. flyweight는 다른 유사한 개체와 가능한 한 많은 데이터를 공유하여 메모리 사용을 최소화하는 개체입니다. 단순히 반복되는 표현이 용납할 수 없는 양의 메모리를 사용할 때 객체를 대량으로 사용하는 방법입니다.

**프로그래매틱 예시**

위에서 차 예를 번역합니다. 우선 차 종류와 티 메이커가 있습니다


```C#
// Anything that will be cached is flyweight.
// Types of tea here will be flyweights.
class KarakTea
{
}

// Acts as a factory and saves the tea
class TeaMaker
{
  private Dictionary<string,KarakTea> mAvailableTea = new Dictionary<string,KarakTea>();

  public KarakTea Make(string preference)
  {
    if (!mAvailableTea.ContainsKey(preference))
    {
      mAvailableTea[preference] = new KarakTea();
    }

    return mAvailableTea[preference];
  }
}
```

그리고 주문을 받고 서빙하는 'TeaShop'

```C#
class TeaShop
{
  private Dictionary<int,KarakTea> mOrders = new Dictionary<int,KarakTea>();
  private readonly TeaMaker mTeaMaker;

  public TeaShop(TeaMaker teaMaker)
  {
    mTeaMaker = teaMaker ?? throw new ArgumentNullException("teaMaker", "teaMaker cannot be null");
  }

  public void TakeOrder(string teaType, int table)
  {
    mOrders[table] = mTeaMaker.Make(teaType);
  }

  public void Serve()
  {
    foreach(var table  in mOrders.Keys){
      Console.WriteLine($"Serving Tea to table # {table}");
    }
  }
}
```
그리고 아래와 같이 사용할 수 있습니다.

```C#
var teaMaker = new TeaMaker();
var teaShop = new TeaShop(teaMaker);

teaShop.TakeOrder("less sugar", 1);
teaShop.TakeOrder("more milk", 2);
teaShop.TakeOrder("without sugar", 5);

teaShop.Serve();
// Serving tea to table# 1
// Serving tea to table# 2
// Serving tea to table# 5
```

🎱 Proxy
-------------------
실제 사례
> 출입 카드를 사용하여 문을 통과한 적이 있습니까? 해당 문을 여는 방법에는 여러 가지가 있습니다. 즉, 액세스 카드를 사용하거나 보안을 우회하는 버튼을 눌러 열 수 있습니다. 문의 주요 기능은 여는 것이지만 일부 기능을 추가하기 위해 그 위에 추가된 프록시가 있습니다. 아래 코드 예제를 사용하여 더 잘 설명하겠습니다.

평범한 말로
> 프록시 패턴을 사용하여 클래스는 다른 클래스의 기능을 나타냅니다.

위키백과 말한다
> 가장 일반적인 형태의 프록시는 다른 항목에 대한 인터페이스 역할을 하는 클래스입니다. 프록시는 배후에서 실제 제공 개체에 액세스하기 위해 클라이언트가 호출하는 래퍼 또는 에이전트 개체입니다. 프록시를 사용하면 단순히 실제 개체로 전달하거나 추가 논리를 제공할 수 있습니다. 프록시에서 추가 기능을 제공할 수 있습니다. 예를 들어 실제 개체에 대한 작업이 리소스를 많이 사용하는 경우 캐싱하거나 실제 개체에 대한 작업이 호출되기 전에 전제 조건을 확인합니다.

**프로그래매틱 예시**

위에서 보안 도어를 예로 들어 보겠습니다. 먼저 도어 인터페이스와 도어 구현이 있습니다.


```C#
interface IDoor
{
  void Open();
  void Close();
}

class LabDoor : IDoor
{
  public void Close()
  {
    Console.WriteLine("Closing lab door");
  }

  public void Open()
  {
    Console.WriteLine("Opening lab door");
  }
}
```
그런 다음 원하는 모든 문을 보호할 수 있는 프록시가 있습니다.
```C#
class SecuredDoor : IDoor
{
  private IDoor mDoor;

  public SecuredDoor(IDoor door)
  {
    mDoor = door ?? throw new ArgumentNullException("door", "door can not be null");
  }

  public void Open(string password)
  {
    if (Authenticate(password))
    {
      mDoor.Open();
    }
    else
    {
      Console.WriteLine("Big no! It ain't possible.");
    }
  }

  private bool Authenticate(string password)
  {
    return password == "$ecr@t";
  }

  public void Close()
  {
    mDoor.Close();
  }
}
```
사용 방법은 다음과 같습니다.
```C#
var door = new SecuredDoor(new LabDoor());
door.Open("invalid"); // Big no! It ain't possible.

door.Open("$ecr@t"); // Opening lab door
door.Close(); // Closing lab door
```
또 다른 예는 일종의 데이터 매퍼 구현입니다. 예를 들어, 나는 최근에 매직 메소드 `call()`을 활용하면서 mongo 클래스 주위에 프록시를 작성한 이 패턴을 사용하여 Mongo DB용 ODM(Object Data Mapper)을 만들었습니다. 모든 메서드 호출은 원래 mongo 클래스에 프록시되었고 검색된 결과는 그대로 반환되었지만 `find` 또는 `find One`의 경우 데이터가 필요한 클래스 객체에 매핑되고 `Cursor` 대신 객체가 반환되었습니다.

Behavioral Design Patterns
==========================

평범한 말로
> 개체 간의 책임 할당과 관련이 있습니다. 구조적 패턴과 다른 점은 구조를 지정할 뿐만 아니라 그들 사이의 메시지 전달/통신 패턴을 개략적으로 설명한다는 것입니다. 즉, "소프트웨어 구성 요소에서 동작을 실행하는 방법"에 대한 답변을 지원합니다.

위키백과 말한다
> 소프트웨어 엔지니어링에서 동작 디자인 패턴은 개체 간의 일반적인 통신 패턴을 식별하고 이러한 패턴을 실현하는 디자인 패턴입니다. 그렇게 함으로써 이러한 패턴은 이 통신을 수행할 때 유연성을 증가시킵니다.

* [Chain of Responsibility](#-chain-of-responsibility)
* [Command](#-command)
* [Iterator](#-iterator)
* [Mediator](#-mediator)
* [Memento](#-memento)
* [Observer](#-observer)
* [Visitor](#-visitor)
* [Strategy](#-strategy)
* [State](#-state)
* [Template Method](#-template-method)

🔗 Chain of Responsibility
-----------------------

실제 사례
> 예를 들어 계정에 세 가지 결제 수단(`A`, `B` 및 `C`)이 설정되어 있습니다. 각각 다른 양을 가지고 있습니다. `A`는 100 USD, `B`는 300 USD, `C`는 1000 USD를 가지고 있으며 지불 선호도는 `A` 다음에 `B` 다음에 `C`로 선택됩니다. 미화 210달러 상당의 물건을 구매하려고 합니다. 책임 사슬을 사용하여 먼저 'A' 계정이 구매가 가능한지 확인하고, 그렇다면 구매가 이루어지고 체인이 끊어집니다. 그렇지 않은 경우 요청은 'B' 계정으로 이동하여 예 체인이 끊어지면 금액을 확인합니다. 그렇지 않으면 적절한 핸들러를 찾을 때까지 요청이 계속 전달됩니다. 여기서 'A', 'B' 및 'C'는 사슬의 연결 고리이며 전체 현상은 책임 사슬입니다.

평범한 말로
> 개체 체인을 구축하는 데 도움이 됩니다. 요청은 한쪽 끝에서 시작하여 적절한 핸들러를 찾을 때까지 개체에서 개체로 계속 이동합니다.

위키백과 말한다
> 객체 지향 설계에서 책임 사슬 패턴은 명령 객체의 소스와 일련의 처리 객체로 구성된 설계 패턴입니다. 각 처리 개체에는 처리할 수 있는 명령 개체의 유형을 정의하는 논리가 포함되어 있습니다. 나머지는 체인의 다음 처리 개체로 전달됩니다.

**프로그래매틱 예시**

위의 계정 예를 번역합니다. 먼저 계정을 함께 연결하는 논리가 있는 기본 계정과 일부 계정이 있습니다.


```C#
abstract class Account
{
  private Account mSuccessor;
  protected decimal mBalance;

  public void SetNext(Account account)
  {
    mSuccessor = account;
  }

  public void Pay(decimal amountTopay)
  {
    if (CanPay(amountTopay))
    {
      Console.WriteLine($"Paid {amountTopay:c} using {this.GetType().Name}.");
    }
    else if (this.mSuccessor != null)
    {
      Console.WriteLine($"Cannot pay using {this.GetType().Name}. Proceeding..");
      mSuccessor.Pay(amountTopay);
    }
    else
    {
      throw new Exception("None of the accounts have enough balance");
    }
  }
  private bool CanPay(decimal amount)
  {
    return mBalance >= amount;
  }
}

class Bank : Account
{
  public Bank(decimal balance)
  {
    this.mBalance = balance;
  }
}

class Paypal : Account
{
  public Paypal(decimal balance)
  {
    this.mBalance = balance;
  }
}

class Bitcoin : Account
{
  public Bitcoin(decimal balance)
  {
    this.mBalance = balance;
  }
}
```

이제 위에서 정의한 링크(예: Bank, Paypal, Bitcoin)를 사용하여 체인을 준비하겠습니다.

```C#
// Let's prepare a chain like below
//      $bank->$paypal->$bitcoin
//
// First priority bank
//      If bank can't pay then paypal
//      If paypal can't pay then bit coin
var bank = new Bank(100);          // Bank with balance 100
var paypal = new Paypal(200);      // Paypal with balance 200
var bitcoin = new Bitcoin(300);    // Bitcoin with balance 300

bank.SetNext(paypal);
paypal.SetNext(bitcoin);

// Let's try to pay using the first priority i.e. bank
bank.Pay(259);
// Output will be
// ==============
// Cannot pay using bank. Proceeding ..
// Cannot pay using paypal. Proceeding ..:
// Paid 259 using Bitcoin!
```

👮 Command
-------

실제 사례
> 일반적인 예는 식당에서 음식을 주문하는 것입니다. 당신(즉, `Client`)은 웨이터(즉, `Invoker`)에게 음식을 가져오라고 요청하고(즉, `Command`) 웨이터는 단순히 요리할 내용과 방법에 대한 지식이 있는 셰프(즉, `Receiver`)에게 요청을 전달합니다. .
> 또 다른 예는 리모콘(`Invoker`)을 사용하여 TV(즉 `Receiver`)를 켜는(즉 `Command`) 사용자(`Client`)입니다.

평범한 말로
> 개체에 작업을 캡슐화할 수 있습니다. 이 패턴의 핵심 아이디어는 수신자로부터 클라이언트를 분리하는 수단을 제공하는 것입니다.

위키백과 말한다
> 개체 지향 프로그래밍에서 명령 패턴은 동작을 수행하거나 나중에 이벤트를 트리거하는 데 필요한 모든 정보를 캡슐화하는 데 개체를 사용하는 행동 설계 패턴입니다. 이 정보에는 메서드 이름, 메서드를 소유하는 개체 및 메서드 매개 변수 값이 포함됩니다.

**프로그래매틱 예시**

먼저 수행할 수 있는 모든 작업을 구현한 수신기가 있습니다.
```C#
// Receiver
class Bulb
{
  public void TurnOn()
  {
    Console.WriteLine("Bulb has been lit");
  }

  public void TurnOff()
  {
    Console.WriteLine("Darkness!");
  }
}
```
그런 다음 각 명령이 구현할 인터페이스가 있고 명령 세트가 있습니다.
```C#
interface ICommand
{
  void Execute();
  void Undo();
  void Redo();
}

// Command
class TurnOn : ICommand
{
  private Bulb mBulb;

  public TurnOn(Bulb bulb)
  {
    mBulb = bulb ?? throw new ArgumentNullException("Bulb", "Bulb cannot be null");
  }

  public void Execute()
  {
    mBulb.TurnOn();
  }

  public void Undo()
  {
    mBulb.TurnOff();
  }

  public void Redo()
  {
    Execute();
  }
}

class TurnOff : ICommand
{
  private Bulb mBulb;

  public TurnOff(Bulb bulb)
  {
    mBulb = bulb ?? throw new ArgumentNullException("Bulb", "Bulb cannot be null");
  }

  public void Execute()
  {
    mBulb.TurnOff();
  }

  public void Undo()
  {
    mBulb.TurnOn();
  }

  public void Redo()
  {
    Execute();
  }
}
```
그런 다음 클라이언트가 명령을 처리하기 위해 상호 작용할 'Invoker'가 있습니다.
```C#
// Invoker
class RemoteControl
{
  public void Submit(ICommand command)
  {
    command.Execute();
  }
}
```
마지막으로 클라이언트에서 어떻게 사용할 수 있는지 살펴보겠습니다.
```C#
  var bulb = new Bulb();

  var turnOn = new TurnOn(bulb);
  var turnOff = new TurnOff(bulb);

  var remote = new RemoteControl();
  remote.Submit(turnOn); // Bulb has been lit!
  remote.Submit(turnOff); // Darkness!

  Console.ReadLine();
```

명령 패턴은 트랜잭션 기반 시스템을 구현하는 데에도 사용할 수 있습니다. 명령을 실행하자마자 명령 기록을 계속 유지 관리하는 곳. 마지막 명령이 성공적으로 실행되면 그렇지 않으면 기록을 반복하고 실행된 모든 명령에서 '실행 취소'를 계속 실행합니다.

➿ Iterator
--------

실제 사례
> 이전 라디오 세트는 사용자가 일부 채널에서 시작한 다음 다음 또는 이전 버튼을 사용하여 각 채널을 이동할 수 있는 반복자의 좋은 예입니다. 또는 다음 및 이전 버튼을 눌러 연속 채널을 이동할 수 있는 MP3 플레이어 또는 TV 세트의 예를 들어 보십시오.

평범한 말로
> 기본 프레젠테이션을 노출하지 않고 개체의 요소에 액세스하는 방법을 제시합니다.

위키백과 말한다
> 객체 지향 프로그래밍에서 반복자 패턴은 반복자가 컨테이너를 순회하고 컨테이너의 요소에 액세스하는 데 사용되는 디자인 패턴입니다. 반복자 패턴은 컨테이너에서 알고리즘을 분리합니다. 경우에 따라 알고리즘은 반드시 컨테이너별로 다르므로 분리할 수 없습니다.

**프로그래매틱 예시**

C#에서는 IEnumerable<T>를 구현하여 수행할 수 있습니다. 위의 라디오 통계 이온 예제를 번역합니다. 먼저 'RadioStation'이 있습니다.

```C#
class RadioStation
{
  private float mFrequency;

  public RadioStation(float frequency)
  {
    mFrequency = frequency;
  }

  public float GetFrequecy()
  {
    return mFrequency;
  }

}

```
그런 다음 반복자가 있습니다.

```C#
class StationList : IEnumerable<RadioStation>
{
  List<RadioStation> mStations = new List<RadioStation>();

  public RadioStation this[int index]
  {
    get { return mStations[index]; }
    set { mStations.Insert(index, value); }
  }

  public void Add(RadioStation station)
  {
    mStations.Add(station);
  }

  public void Remove(RadioStation station)
  {
    mStations.Remove(station);
  }

  public IEnumerator<RadioStation> GetEnumerator()
  {
    return this.GetEnumerator();
  }

  IEnumerator IEnumerable.GetEnumerator()
  {
    //Use can switch to this internal collection if you do not want to transform
    //return mStations.GetEnumerator();

    //use this if you want to transform the object before rendering
    foreach (var x in mStations)
    {
      yield return x;
    }
  }
}
```
그런 다음 다음과 같이 사용할 수 있습니다.
```C#
var stations = new StationList();
var station1 = new RadioStation(89);
stations.Add(station1);

var station2 = new RadioStation(101);
stations.Add(station2);

var station3 = new RadioStation(102);
stations.Add(station3);

foreach(var x in stations)
{
  Console.Write(x.GetFrequecy());
}

var q = stations.Where(x => x.GetFrequecy() == 89).FirstOrDefault();
Console.WriteLine(q.GetFrequecy());

Console.ReadLine();
```

👽 Mediator
========

실제 사례
> 일반적인 예는 휴대 전화로 누군가와 대화할 때 네트워크 제공업체가 귀하와 그들 사이에 있으며 귀하의 대화가 직접 전송되는 대신 이를 통해 진행되는 것입니다. 이 경우 네트워크 공급자는 중재자입니다.

평범한 말로
> 중재자 패턴은 제3자 개체(중재자라고 함)를 추가하여 두 개체(동료라고 함) 간의 상호 작용을 제어합니다. 서로 통신하는 클래스 간의 결합을 줄이는 데 도움이 됩니다. 이제 그들은 서로의 구현에 대한 지식을 가질 필요가 없기 때문입니다.

위키백과 말한다
> 소프트웨어 엔지니어링에서 중재자 패턴은 개체 집합이 상호 작용하는 방식을 캡슐화하는 개체를 정의합니다. 이 패턴은 프로그램의 실행 동작을 변경할 수 있는 방식으로 인해 동작 패턴으로 간주됩니다.

**프로그래매틱 예시**

다음은 사용자(예: 동료)가 서로에게 메시지를 보내는 대화방(예: 중재자)의 가장 간단한 예입니다.

우선 중재자 즉 채팅방이 있습니다.


```C#
interface IChatRoomMediator
{
  void ShowMessage(User user, string message);
}

//Mediator
class ChatRoom : IChatRoomMediator
{
  public void ShowMessage(User user, string message)
  {
    Console.WriteLine($"{DateTime.Now.ToString("MMMM dd, H:mm")} [{user.GetName()}]:{message}");
  }
}
```

그런 다음 사용자, 즉 동료가 있습니다.
```C#
class User
{
  private string mName;
  private IChatRoomMediator mChatRoom;

  public User(string name, IChatRoomMediator chatroom)
  {
    mChatRoom = chatroom;
    mName = name;
  }

  public string GetName()
  {
    return mName;
  }

  public void Send(string message)
  {
    mChatRoom.ShowMessage(this, message);
  }
}
```
그리고 사용법
```C#
var mediator = new ChatRoom();

var john = new User("John", mediator);
var jane = new User("Jane", mediator);

john.Send("Hi there!");
jane.Send("Hey!");

//April 14, 20:05[John]:Hi there!
//April 14, 20:05[Jane]:Hey!
```

💾 Memento
-------
실제 사례
> 계산기(예: 발신자)의 예를 들어 계산을 수행할 때마다 마지막 계산이 메모리(예: memento)에 저장되어 다시 돌아가서 일부 작업 버튼(예: 관리인)을 사용하여 복원할 수 있습니다.

평범한 말로
> Memento 패턴은 나중에 원활하게 복원할 수 있는 방식으로 개체의 현재 상태를 캡처하고 저장하는 것입니다.

위키백과 말한다
> 메멘토 패턴은 개체를 이전 상태로 복원하는 기능을 제공하는 소프트웨어 설계 패턴입니다(롤백을 통해 실행 취소).

일종의 실행 취소 기능을 제공해야 할 때 일반적으로 유용합니다.

**프로그래매틱 예시**

수시로 상태를 저장하고 원하는 경우 복원할 수 있는 텍스트 편집기의 예를 들어 보겠습니다.

우선 에디터 상태를 유지할 수 있는 메멘토 객체가 있습니다.

```C#
class EditorMemento
{
  private string mContent;

  public EditorMemento(string content)
  {
    mContent = content;
  }

  public string Content
  {
    get
    {
      return mContent;
    }
  }
}
```

그런 다음 memento 객체를 사용할 편집자, 즉 작성자가 있습니다.

```C#
class Editor {

  private string mContent = string.Empty;
  private EditorMemento memento;

  public Editor()
  {
    memento = new EditorMemento(string.Empty);
  }

  public void Type(string words)
  {
    mContent = String.Concat(mContent," ", words);
  }

  public string Content
  {
    get
    {
      return mContent;
    }
  }

  public void Save()
  {
    memento = new EditorMemento(mContent);
  }

  public void Restore()
  {
    mContent = memento.Content;
  }
}
```

그런 다음 다음과 같이 사용할 수 있습니다.

```C#
var editor = new Editor();

//Type some stuff
editor.Type("This is the first sentence.");
editor.Type("This is second.");

// Save the state to restore to : This is the first sentence. This is second.
editor.Save();

//Type some more
editor.Type("This is third.");

//Output the content
Console.WriteLine(editor.Content); // This is the first sentence. This is second. This is third.

//Restoring to last saved state
editor.Restore();

Console.Write(editor.Content); // This is the first sentence. This is second

```

😎 Observer
--------
실제 사례
> 좋은 예는 구인 사이트에 가입한 구직자들이며 일치하는 채용 기회가 있을 때마다 알림을 받습니다.

평범한 말로
> 개체가 상태를 변경할 때마다 모든 종속 항목에 알림이 표시되도록 개체 간의 종속성을 정의합니다.

위키백과 말한다
> 옵저버 패턴은 주제라고 하는 개체가 옵저버라고 하는 종속 항목 목록을 유지 관리하고 일반적으로 메서드 중 하나를 호출하여 상태 변경을 자동으로 알리는 소프트웨어 설계 패턴입니다.

**프로그래매틱 예시**

위의 예를 번역합니다. 먼저 채용 공고에 대한 알림이 필요한 구직자가 있습니다.
```C#
class JobPost
{
  public string Title { get; private set; }

  public JobPost(string title)
  {
    Title = title;
  }
}
class JobSeeker : IObserver<JobPost>
{
  public string Name { get; private set; }

  public JobSeeker(string name)
  {
    Name = name;
  }

  //Method is not being called by JobPostings class currently
  public void OnCompleted()
  {
    //No Implementation
  }

  //Method is not being called by JobPostings class currently
  public void OnError(Exception error)
  {
    //No Implementation
  }

  public void OnNext(JobPost value)
  {
    Console.WriteLine($"Hi {Name} ! New job posted: {value.Title}");
  }
}
```
그런 다음 구직자가 구독할 채용 공고가 있습니다.
```C#
class JobPostings : IObservable<JobPost>
{
  private List<IObserver<JobPost>> mObservers;
  private List<JobPost> mJobPostings;

  public JobPostings()
  {
    mObservers = new List<IObserver<JobPost>>();
    mJobPostings = new List<JobPost>();
  }

  public IDisposable Subscribe(IObserver<JobPost> observer)
  {
    // Check whether observer is already registered. If not, add it
    if (!mObservers.Contains(observer))
    {
      mObservers.Add(observer);
    }
    return new Unsubscriber<JobPost>(mObservers, observer);
  }

  private void Notify(JobPost jobPost)
  {
    foreach(var observer in mObservers)
    {
      observer.OnNext(jobPost);
    }
  }

  public void AddJob(JobPost jobPost)
  {
    mJobPostings.Add(jobPost);
    Notify(jobPost);
  }

}

internal class Unsubscriber<JobPost> : IDisposable
{
  private List<IObserver<JobPost>> mObservers;
  private IObserver<JobPost> mObserver;

  internal Unsubscriber(List<IObserver<JobPost>> observers, IObserver<JobPost> observer)
  {
    this.mObservers = observers;
    this.mObserver = observer;
  }

  public void Dispose()
  {
    if (mObservers.Contains(mObserver))
      mObservers.Remove(mObserver);
  }
}
```
그런 다음 다음과 같이 사용할 수 있습니다.
```C#
//Create Subscribers
var johnDoe = new JobSeeker("John Doe");
var janeDoe = new JobSeeker("Jane Doe");

//Create publisher and attch subscribers
var jobPostings = new JobPostings();
jobPostings.Subscribe(johnDoe);
jobPostings.Subscribe(janeDoe);

//Add a new job and see if subscribers get notified
jobPostings.AddJob(new JobPost("Software Engineer"));

//Output
// Hi John Doe! New job posted: Software Engineer
// Hi Jane Doe! New job posted: Software Engineer

Console.ReadLine();
```

🏃 Visitor
-------
실제 사례
> 두바이를 방문하는 사람을 생각해 보십시오. 두바이에 입국하는 방법(즉, 비자)만 있으면 됩니다. 도착 후 허가를 요청하거나 이곳을 방문하기 위해 약간의 다리 작업을 할 필요 없이 스스로 두바이의 모든 곳을 방문할 수 있습니다. 장소를 알려주면 방문할 수 있습니다. 방문자 패턴을 사용하면 방문할 장소를 추가하여 다리 작업을 하지 않고도 최대한 많이 방문할 수 있습니다.

평범한 말로
> 방문자 패턴을 사용하면 개체를 수정하지 않고도 개체에 추가 작업을 추가할 수 있습니다.

위키백과 말한다
> 개체 지향 프로그래밍 및 소프트웨어 엔지니어링에서 방문자 디자인 패턴은 알고리즘이 작동하는 개체 구조에서 알고리즘을 분리하는 방법입니다. 이러한 분리의 실질적인 결과는 기존 개체 구조를 수정하지 않고 새 작업을 기존 개체 구조에 추가하는 기능입니다. 개방/폐쇄 원칙을 따르는 한 가지 방법입니다.

**프로그래매틱 예시**

여러 종류의 동물이 있고 그것들을 소리로 만들어야 하는 동물원 시뮬레이션의 예를 들어 봅시다. 방문자 패턴을 사용하여 이것을 번역해 보겠습니다.

```C#
// Visitee
interface IAnimal
{
  void Accept(IAnimalOperation operation);
}

// Visitor
interface IAnimalOperation
{
  void VisitMonkey(Monkey monkey);
  void VisitLion(Lion lion);
  void VisitDolphin(Dolphin dolphin);
}
```
그런 다음 동물에 대한 구현이 있습니다.
```C#
class Monkey : IAnimal
{
  public void Shout()
  {
    Console.WriteLine("Oooh o aa aa!");
  }

  public void Accept(IAnimalOperation operation)
  {
      operation.VisitMonkey(this);
  }
}

class Lion : IAnimal
{
  public void Roar()
  {
    Console.WriteLine("Roaar!");
  }

  public void Accept(IAnimalOperation operation)
  {
      operation.VisitLion(this);
  }
}

class Dolphin : IAnimal
{
  public void Speak()
  {
    Console.WriteLine("Tuut tittu tuutt!");
  }

  public void Accept(IAnimalOperation operation)
  {
      operation.VisitDolphin(this);
  }
}
```
방문자를 구현해 봅시다
```C#
class Speak : IAnimalOperation
{
  public void VisitDolphin(Dolphin dolphin)
  {
    dolphin.Speak();
  }

  public void VisitLion(Lion lion)
  {
    lion.Roar();
  }

  public void VisitMonkey(Monkey monkey)
  {
    monkey.Shout();
  }
}
```

그런 다음 다음과 같이 사용할 수 있습니다.
```C#
var monkey = new Monkey();
var lion = new Lion();
var dolphin = new Dolphin();

var speak = new Speak();

monkey.Accept(speak);    // Ooh oo aa aa!
lion.Accept(speak);      // Roaaar!
dolphin.Accept(speak);   // Tuut tutt tuutt!

```
우리는 단순히 동물에 대한 상속 계층 구조를 가짐으로써 이를 수행할 수 있었지만 동물에 새 작업을 추가해야 할 때마다 동물을 수정해야 했습니다. 그러나 이제 우리는 그것들을 바꿀 필요가 없을 것입니다. 예를 들어 동물에게 점프 동작을 추가하라는 요청을 받았다고 가정해 보겠습니다. 새 방문자를 생성하여 간단하게 추가할 수 있습니다.

```C#
class Jump : IAnimalOperation
{
  public void VisitDolphin(Dolphin dolphin)
  {
    Console.WriteLine("Walked on water a little and disappeared!");
  }

  public void VisitLion(Lion lion)
  {
    Console.WriteLine("Jumped 7 feet! Back on the ground!");
  }

  public void VisitMonkey(Monkey monkey)
  {
    Console.WriteLine("Jumped 20 feet high! on to the tree!");
  }
}
```
그리고 사용법을 위해
```C#
var jump = new Jump();

monkey.Accept(speak);   // Ooh oo aa aa!
monkey.Accept(jump);    // Jumped 20 feet high! on to the tree!

lion.Accept(speak);     // Roaaar!
lion.Accept(jump);      // Jumped 7 feet! Back on the ground!

dolphin.Accept(speak);  // Tuut tutt tuutt!
dolphin.Accept(jump);   // Walked on water a little and disappeared

```

💡 Strategy
--------

실제 사례
> 정렬의 예를 고려하여 버블 정렬을 구현했지만 데이터가 증가하기 시작했고 버블 정렬이 매우 느려지기 시작했습니다. 이를 해결하기 위해 퀵 정렬을 구현했습니다. 그러나 지금은 빠른 정렬 알고리즘이 큰 데이터 세트에 대해 더 잘 작동하지만 작은 데이터 세트에 대해서는 매우 느립니다. 이를 처리하기 위해 작은 데이터 세트의 경우 버블 정렬을 사용하고 더 크고 빠른 정렬을 위한 전략을 구현했습니다.

평범한 말로
> 전략 패턴을 사용하면 상황에 따라 알고리즘 또는 전략을 전환할 수 있습니다.

위키백과 말한다
> 컴퓨터 프로그래밍에서 전략 패턴(정책 패턴이라고도 함)은 런타임에 알고리즘의 동작을 선택할 수 있도록 하는 동작 소프트웨어 설계 패턴입니다.

**프로그래매틱 예시**

위의 예를 번역합니다. 우선 전략 인터페이스와 다양한 전략 구현이 있습니다.

```C#
interface ISortStrategy
{
  List<int> Sort(List<int> dataset);
}

class BubbleSortStrategy : ISortStrategy
{
  public List<int> Sort(List<int> dataset)
  {
    Console.WriteLine("Sorting using Bubble Sort !");
    return dataset;
  }
}

class QuickSortStrategy : ISortStrategy
{
  public List<int> Sort(List<int> dataset)
  {
    Console.WriteLine("Sorting using Quick Sort !");
    return dataset;
  }
}
```

그리고 어떤 전략이든 사용할 고객이 있습니다.
```C#
class Sorter
{
  private readonly ISortStrategy mSorter;

  public Sorter(ISortStrategy sorter)
  {
    mSorter = sorter;
  }

  public List<int> Sort(List<int> unSortedList)
  {
    return mSorter.Sort(unSortedList);
  }
}
```
그리고 다음과 같이 사용할 수 있습니다.
```C#
var unSortedList = new List<int> { 1, 10, 2, 16, 19 };

var sorter = new Sorter(new BubbleSortStrategy());
sorter.Sort(unSortedList); // // Output : Sorting using Bubble Sort !

sorter = new Sorter(new QuickSortStrategy());
sorter.Sort(unSortedList); // // Output : Sorting using Quick Sort !
```

💢 State
-----
실제 사례
> 그리기 응용 프로그램을 사용 중이고 그릴 페인트 브러시를 선택한다고 상상해 보십시오. 이제 브러시는 선택한 색상에 따라 동작을 변경합니다. 즉, 빨간색을 선택한 경우 빨간색으로, 파란색인 경우 파란색으로 그리는 식입니다.

평범한 말로
> 상태가 변경될 때 클래스의 동작을 변경할 수 있습니다.

위키백과 말한다
> 상태 패턴은 객체 지향 방식으로 상태 머신을 구현하는 동작 소프트웨어 설계 패턴입니다. 상태 패턴을 사용하면 각 개별 상태를 상태 패턴 인터페이스의 파생 클래스로 구현하고 패턴의 슈퍼클래스에서 정의한 메서드를 호출하여 상태 전환을 구현하여 상태 머신을 구현합니다.
> 상태 패턴은 패턴의 인터페이스에 정의된 메서드 호출을 통해 현재 전략을 전환할 수 있는 전략 패턴으로 해석할 수 있습니다.

**프로그래매틱 예시**

텍스트 편집기의 예를 들어 보겠습니다. 입력된 텍스트의 상태를 변경할 수 있습니다.

우선 상태 인터페이스와 일부 상태 구현이 있습니다.

```C#
interface IWritingState {

  void Write(string words);

}

class UpperCase : IWritingState
{
  public void Write(string words)
  {
    Console.WriteLine(words.ToUpper());
  }
}

class LowerCase : IWritingState
{
  public void Write(string words)
  {
    Console.WriteLine(words.ToLower());
  }
}

class DefaultText : IWritingState
{
  public void Write(string words)
  {
    Console.WriteLine(words);
  }
}
```
그런 다음 편집자가 있습니다.
```C#
class TextEditor {

  private IWritingState mState;

  public TextEditor()
  {
    mState = new DefaultText();
  }

  public void SetState(IWritingState state)
  {
    mState = state;
  }

  public void Type(string words)
  {
    mState.Write(words);
  }

}
```
그런 다음 다음과 같이 사용할 수 있습니다.
```C#
var editor = new TextEditor();

editor.Type("First line");

editor.SetState(new UpperCase());

editor.Type("Second Line");
editor.Type("Third Line");

editor.SetState(new LowerCase());

editor.Type("Fourth Line");
editor.Type("Fifthe Line");

// Output:
// First line
// SECOND LINE
// THIRD LINE
// fourth line
// fifth line
```

📒 Template Method
---------------

실제 사례
> 집을 지었다고 가정해 보겠습니다. 구축 단계는 다음과 같습니다.
> - 집의 기반을 준비
> - 벽을 구축
> - 지붕 추가
> - 다른 층 추가

> 이 단계의 순서는 절대 변경할 수 없습니다. 즉, 벽 등을 만들기 전에 지붕을 만들 수 없지만 각 단계는 수정할 수 있습니다.

평범한 말로
> 템플릿 방법은 특정 알고리즘이 수행될 수 있는 방법의 골격을 정의하지만 해당 단계의 구현을 하위 클래스에 맡깁니다.

위키백과 말한다
> 소프트웨어 엔지니어링에서 템플릿 메서드 패턴은 작업에서 알고리즘의 프로그램 골격을 정의하고 일부 단계를 하위 클래스로 연기하는 동작 설계 패턴입니다. 알고리즘의 구조를 변경하지 않고 알고리즘의 특정 단계를 재정의할 수 있습니다.

**프로그래매틱 예시**

테스트, 린트, 빌드, 빌드 보고서(예: 코드 커버리지 보고서, 린팅 보고서 등)를 생성하고 테스트 서버에 앱을 배포하는 데 도움이 되는 빌드 도구가 있다고 상상해 보세요.

우선 빌드 알고리즘의 골격을 지정하는 기본 클래스가 있습니다.
```C#
abstract class Builder
{
    // Template method
    public void Build()
    {
      Test();
      Lint();
      Assemble();
      Deploy();
    }

    abstract public void Test();
    abstract public void Lint();
    abstract public void Assemble();
    abstract public void Deploy();
}
```

그런 다음 구현을 할 수 있습니다.

```C#
class AndroidBuilder : Builder
{
  public override void Assemble()
  {
    Console.WriteLine("Assembling the android build");
  }

  public override void Deploy()
  {
    Console.WriteLine("Deploying android build to server");
  }

  public override void Lint()
  {
    Console.WriteLine("Linting the android code");
  }

  public override void Test()
  {
    Console.WriteLine("Running android tests");
  }
}


class IosBuilder : Builder
{
  public override void Assemble()
  {
    Console.WriteLine("Assembling the ios build");
  }

  public override void Deploy()
  {
    Console.WriteLine("Deploying ios build to server");
  }

  public override void Lint()
  {
    Console.WriteLine("Linting the ios code");
  }

  public override void Test()
  {
    Console.WriteLine("Running ios tests");
  }
}

```
그런 다음 다음과 같이 사용할 수 있습니다.

```C#
var androidBuilder = new AndroidBuilder();
androidBuilder.Build();

// Output:
// Running android tests
// Linting the android code
// Assembling the android build
// Deploying android build to server

var iosBuilder = new IosBuilder();
iosBuilder.Build();

// Output:
// Running ios tests
// Linting the ios code
// Assembling the ios build
// Deploying ios build to server
```

## 🚦 사람들을 마무리

그리고 그것에 대해 마무리합니다. 나는 이것을 계속 개선할 것이므로 이 저장소를 보고/별표 표시하여 다시 방문할 수 있습니다. 또한 건축 패턴에 대해서도 같은 글을 쓸 계획이 있으니 계속 지켜봐 주시기 바랍니다.

## 👬 기부금

- Report issues
- Open pull request with improvements
- Spread the word
- Contact me on <a href="https://twitter.com/anupavanm">Twitter</a> 

## 특허

[![License: CC BY 4.0](https://img.shields.io/badge/License-CC%20BY%204.0-lightgrey.svg)](https://creativecommons.org/licenses/by/4.0/)
