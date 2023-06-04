using System;
using System.Text;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace DesignPatterns_ForHuman_ForCSharp_ForKorean {
    class Test {
        public static void FactoryPattern_Test() => FactoryPattern.Test.Run();
        public static void FactoryMethodPattern_Test() => FactoryMethodPattern.Test.Run();
        public static void AbstractFactoryPattern_Test() => AbstractFactoryPattern.Test.Run();
        public static void BuilderPattern_Test() => BuilderPattern.Test.Run();
        public static void PrototypePattern_Test() => PrototypePattern.Test.Run();
        public static void SingletonPattern_Test() => SingletonPattern.Test.Run();
        public static void AdapterPattern_Test() => AdapterPattern.Test.Run();
        public static void BridgePattern_Test() => BridgePattern.Test.Run();
        public static void CompositePattern_Test() => CompositePattern.Test.Run();
        public static void DecoratorPattern_Test() => DecoratorPattern.Test.Run();
        public static void FacadePattern_Test() => FacadePattern.Test.Run();
        public static void FlyweightPattern_Test() => FlyweightPattern.Test.Run();
        public static void ProxyPattern_Test() => ProxyPattern.Test.Run();
        public static void ChainOfResponsibilityPattern_Test() => ChainOfResponsibilityPattern.Test.Run();
        public static void CommandPattern_Test() => CommandPattern.Test.Run();
        public static void IteratorPattern_Test() => IteratorPattern.Test.Run();
        public static void MediatorPattern_Test() => MediatorPattern.Test.Run();
        public static void MementoPattern_Test() => MementoPattern.Test.Run();
        public static void ObserverPattern_Test() => ObserverPattern.Test.Run();
        public static void VisitorPattern_Test() => VisitorPattern.Test.Run();
        public static void StrategyPattern_Test() => StrategyPattern.Test.Run();
        public static void StatePattern_Test() => StatePattern.Test.Run();
        public static void TemplateMethodPattern_Test() => TemplateMethodPattern.Test.Run();
    }
}


namespace FactoryPattern {
    public interface IDoor {
        int GetHeight();
        int GetWidth();
    }

    public class WoodenDoor : IDoor {
        private int Height { get; set; }
        private int Width { get; set; }

        public WoodenDoor(int height, int width) {
            this.Height = height;
            this.Width = width;
        }

        public int GetHeight() {
            return this.Height;
        }
        public int GetWidth() {
            return this.Width;
        }
    }

    public static class DoorFactory {
        public static IDoor MakeDoor(int height, int width) {
            return new WoodenDoor(height, width);
        }
    }
    class Test {
        public static void Run() {
            var door = DoorFactory.MakeDoor(80, 30);
            Console.WriteLine("Height of Door : {0}", door.GetHeight());
            Console.WriteLine("Width of Door : {0}", door.GetWidth());
            Console.ReadLine();
        }
    }
}


namespace FactoryMethodPattern {
    interface IInterviewer {
        void AskQuestions();
    }

    class Developer : IInterviewer {
        public void AskQuestions() {
            Console.WriteLine("Asking about design patterns!");
        }
    }

    class CommunityExecutive : IInterviewer {
        public void AskQuestions() {
            Console.WriteLine("Asking about community building!");
        }
    }

    abstract class HiringManager {
        // Factory method
        abstract protected IInterviewer MakeInterviewer();
        public void TakeInterview() {
            var interviewer = this.MakeInterviewer();
            interviewer.AskQuestions();
        }
    }

    class DevelopmentManager : HiringManager {
        protected override IInterviewer MakeInterviewer() {
            return new Developer();
        }
    }

    class MarketingManager : HiringManager {
        protected override IInterviewer MakeInterviewer() {
            return new CommunityExecutive();
        }
    }

    class Test {
        public static void Run() {
            var devManager = new DevelopmentManager();
            devManager.TakeInterview(); //Output : Asking about design patterns!

            var marketingManager = new MarketingManager();
            marketingManager.TakeInterview();//Output : Asking about community building!

            Console.ReadLine();
        }
    }
}


namespace AbstractFactoryPattern {
    interface IDoor {

        void GetDescription();

    }
    class WoodenDoor : IDoor {
        public void GetDescription() {
            Console.WriteLine("I am a wooden door");
        }
    }

    class IronDoor : IDoor {
        public void GetDescription() {
            Console.WriteLine("I am a iron door");
        }
    }

    interface IDoorFittingExpert {
        void GetDescription();
    }

    class Welder : IDoorFittingExpert {
        public void GetDescription() {
            Console.WriteLine("I can only fit iron doors");
        }
    }

    class Carpenter : IDoorFittingExpert {
        public void GetDescription() {
            Console.WriteLine("I can only fit wooden doors");
        }
    }

    interface IDoorFactory {
        IDoor MakeDoor();
        IDoorFittingExpert MakeFittingExpert();
    }

    // Wooden factory to return carpenter and wooden door
    class WoodenDoorFactory : IDoorFactory {
        public IDoor MakeDoor() {
            return new WoodenDoor();
        }
        // Iron door factory to get iron door and the relevant fitting expert
        public IDoorFittingExpert MakeFittingExpert() {
            return new Carpenter();
        }
    }

    class IronDoorFactory : IDoorFactory {
        public IDoor MakeDoor() {
            return new IronDoor();
        }

        public IDoorFittingExpert MakeFittingExpert() {
            return new Welder();
        }
    }


    class Test {
        public static void Run() {
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

            Console.ReadLine();
        }
    }
}


namespace BuilderPattern {
    class Test {
        class Burger {
            private int mSize;
            private bool mCheese;
            private bool mPepperoni;
            private bool mLettuce;
            private bool mTomato;

            public Burger(BurgerBuilder builder) {
                this.mSize = builder.Size;
                this.mCheese = builder.Cheese;
                this.mPepperoni = builder.Pepperoni;
                this.mLettuce = builder.Lettuce;
                this.mTomato = builder.Tomato;
            }

            public string GetDescription() {
                var sb = new StringBuilder();
                sb.Append(String.Format("This is {0} inch Burger. ", this.mSize));
                return sb.ToString();
            }
        }

        class BurgerBuilder {
            public int Size;
            public bool Cheese;
            public bool Pepperoni;
            public bool Lettuce;
            public bool Tomato;

            public BurgerBuilder(int size) {
                this.Size = size;
            }

            public BurgerBuilder AddCheese() {
                this.Cheese = true;
                return this;
            }

            public BurgerBuilder AddPepperoni() {
                this.Pepperoni = true;
                return this;
            }

            public BurgerBuilder AddLettuce() {
                this.Lettuce = true;
                return this;
            }

            public BurgerBuilder AddTomato() {
                this.Tomato = true;
                return this;
            }

            public Burger Build() {
                return new Burger(this);
            }
        }

        public static void Run() {
            var burger = new BurgerBuilder(4).AddCheese()
                                              .AddPepperoni()
                                              .AddLettuce()
                                              .AddTomato()
                                              .Build();
            Console.WriteLine(burger.GetDescription());
            Console.ReadLine();
        }
    }
}


namespace PrototypePattern {
    class Sheep {
        public string Name { get; set; }

        public string Category { get; set; }

        public Sheep(string name, string category) {
            Name = name;
            Category = category;
        }

        public Sheep Clone() {
            return MemberwiseClone() as Sheep;
        }
    }

    class Test {
        public static void Run() {
            var original = new Sheep("Jolly", "Mountain Sheep");
            Console.WriteLine(original.Name); // Jolly
            Console.WriteLine(original.Category); // Mountain Sheep

            var cloned = original.Clone();
            cloned.Name = "Dolly";
            Console.WriteLine(cloned.Name); // Dolly
            Console.WriteLine(cloned.Category); // Mountain Sheep
            Console.WriteLine(original.Name); // Dolly

            Console.ReadLine();
        }
    }
}


namespace SingletonPattern {
    public class President {
        static President instance;
        // Private constructor
        private President() {
            //Hiding the Constructor
        }

        // Public constructor
        public static President get_instance() {
            if (instance == null) {
                instance = new President();
            }
            return instance;
        }
    }
    class Test {
        public static void Run() {
            President a = President.get_instance();
            President b = President.get_instance();

            Console.WriteLine((a == b).ToString());
            Console.ReadLine();
        }
    }
}


namespace AdapterPattern {
    interface ILion {
        void Roar();
    }

    class AfricanLion : ILion {
        public void Roar() {

        }
    }

    class AsiaLion : ILion {
        public void Roar() {

        }
    }

    // This needs to be added to the game
    class WildDog {
        public void bark() {
        }
    }

    // Adapter around wild dog to make it compatible with our game
    class WildDogAdapter : ILion {
        private WildDog mDog;
        public WildDogAdapter(WildDog dog) {
            this.mDog = dog;
        }
        public void Roar() {
            mDog.bark();
        }
    }

    class Hunter {
        public void Hunt(ILion lion) {

        }
    }

    class Test {
        public static void Run() {
            var wildDog = new WildDog();
            var wildDogAdapter = new WildDogAdapter(wildDog);

            var hunter = new Hunter();
            hunter.Hunt(wildDogAdapter);

            Console.ReadLine();
        }
    }
}


namespace BridgePattern {
    class Test {
        interface IWebPage {
            string GetContent();
        }

        class About : IWebPage {
            protected ITheme theme;

            public About(ITheme theme) {
                this.theme = theme;
            }

            public string GetContent() {
                return String.Format("About page in {0}", theme.GetColor());
            }
        }

        class Careers : IWebPage {
            protected ITheme theme;

            public Careers(ITheme theme) {
                this.theme = theme;
            }

            public string GetContent() {
                return String.Format("Careers page in {0}", theme.GetColor());
            }
        }

        interface ITheme {
            string GetColor();
        }

        class DarkTheme : ITheme {
            public string GetColor() {
                return "Dark Black";
            }
        }

        class LightTheme : ITheme {
            public string GetColor() {
                return "Off White";
            }
        }

        class AquaTheme : ITheme {
            public string GetColor() {
                return "Light blue";
            }
        }
        public static void Run() {
            var darkTheme = new DarkTheme();

            var about = new About(darkTheme);
            var careers = new Careers(darkTheme);

            Console.WriteLine(about.GetContent());
            Console.WriteLine(careers.GetContent());
            Console.ReadLine();
        }
    }
}


namespace CompositePattern {
    interface IEmployee {
        float GetSalary();
        string GetRole();
        string GetName();
    }


    class Developer : IEmployee {
        private string mName;
        private float mSalary;

        public Developer(string name, float salary) {
            this.mName = name;
            this.mSalary = salary;
        }

        public float GetSalary() {
            return this.mSalary;
        }

        public string GetRole() {
            return "Developer";
        }

        public string GetName() {
            return this.mName;
        }
    }

    class Designer : IEmployee {
        private string mName;
        private float mSalary;

        public Designer(string name, float salary) {
            this.mName = name;
            this.mSalary = salary;
        }

        public float GetSalary() {
            return this.mSalary;
        }

        public string GetRole() {
            return "Designer";
        }

        public string GetName() {
            return this.mName;
        }
    }
    class Organization {
        protected List<IEmployee> employees;

        public Organization() {
            employees = new List<IEmployee>();
        }

        public void AddEmployee(IEmployee employee) {
            employees.Add(employee);
        }

        public float GetNetSalaries() {
            float netSalary = 0;

            foreach (var e in employees) {
                netSalary += e.GetSalary();
            }
            return netSalary;
        }
    }
    class Test {
        public static void Run() {
            var developer = new Developer("John", 5000);
            var designer = new Designer("Arya", 5000);

            var organization = new Organization();
            organization.AddEmployee(developer);
            organization.AddEmployee(designer);
            Console.WriteLine("Net Salary of Emmployees in Organization is {0:c}", organization.GetNetSalaries());
            Console.ReadLine();
        }
    }
}


namespace DecoratorPattern {
    interface ICoffee {
        int GetCost();
        string GetDescription();
    }

    class SimpleCoffee : ICoffee {
        public int GetCost() {
            return 5;
        }

        public string GetDescription() {
            return "Simple Coffee";
        }
    }

    class MilkCoffee : ICoffee {
        private readonly ICoffee mCoffee;

        public MilkCoffee(ICoffee coffee) {
            mCoffee = coffee ?? throw new ArgumentNullException("coffee", "coffee should not be null");
        }
        public int GetCost() {
            return mCoffee.GetCost() + 1;
        }

        public string GetDescription() {
            return String.Concat(mCoffee.GetDescription(), ", milk");
        }
    }

    class WhipCoffee : ICoffee {
        private readonly ICoffee mCoffee;

        public WhipCoffee(ICoffee coffee) {
            mCoffee = coffee ?? throw new ArgumentNullException("coffee", "coffee should not be null");
        }
        public int GetCost() {
            return mCoffee.GetCost() + 1;
        }

        public string GetDescription() {
            return String.Concat(mCoffee.GetDescription(), ", whip");
        }
    }

    class VanillaCoffee : ICoffee {
        private readonly ICoffee mCoffee;

        public VanillaCoffee(ICoffee coffee) {
            mCoffee = coffee ?? throw new ArgumentNullException("coffee", "coffee should not be null");
        }
        public int GetCost() {
            return mCoffee.GetCost() + 1;
        }

        public string GetDescription() {
            return String.Concat(mCoffee.GetDescription(), ", vanilla");
        }
    }
    class Test {
        public static void Run() {
            var myCoffee = new SimpleCoffee();
            Console.WriteLine("{0:c}", myCoffee.GetCost()); // $ 5.00
            Console.WriteLine("{0}", myCoffee.GetDescription()); // Simple Coffee

            var milkCoffee = new MilkCoffee(myCoffee);
            Console.WriteLine("{0:c}", milkCoffee.GetCost()); // $ 6.00
            Console.WriteLine("{0}", milkCoffee.GetDescription()); // Simple Coffee, milk

            var whipCoffee = new WhipCoffee(milkCoffee);
            Console.WriteLine("{0:c}", whipCoffee.GetCost()); // $ 7.00
            Console.WriteLine("{0}", whipCoffee.GetDescription()); // Simple Coffee, milk, whip

            var vanillaCoffee = new VanillaCoffee(whipCoffee);
            Console.WriteLine("{0:c}", vanillaCoffee.GetCost()); // $ 8.00
            Console.WriteLine("{0}", vanillaCoffee.GetDescription()); // Simple Coffee, milk, whip
            Console.ReadLine();
        }
    }
}


namespace FacadePattern {
    class Computer {
        public void GetElectricShock() {
            Console.Write("Ouch!");
        }

        public void MakeSound() {
            Console.Write("Beep beep!");
        }

        public void ShowLoadingScreen() {
            Console.Write("Loading..");
        }

        public void Bam() {
            Console.Write("Ready to be used!");
        }

        public void CloseEverything() {
            Console.Write("Bup bup bup buzzzz!");
        }

        public void Sooth() {
            Console.Write("Zzzzz");
        }

        public void PullCurrent() {
            Console.Write("Haaah!");
        }
    }

    class ComputerFacade {
        private readonly Computer mComputer;

        public ComputerFacade(Computer computer) {
            this.mComputer = computer ?? throw new ArgumentNullException("computer", "computer cannot be null");
        }

        public void TurnOn() {
            mComputer.GetElectricShock();
            mComputer.MakeSound();
            mComputer.ShowLoadingScreen();
            mComputer.Bam();
        }

        public void TurnOff() {
            mComputer.CloseEverything();
            mComputer.PullCurrent();
            mComputer.Sooth();
        }
    }
    class Test {
        public static void Run() {
            var computer = new ComputerFacade(new Computer());
            computer.TurnOn(); // Ouch! Beep beep! Loading.. Ready to be used!
            Console.WriteLine();
            computer.TurnOff();  // Bup bup buzzz! Haah! Zzzzz
            Console.ReadLine();
        }
    }
}


namespace FlyweightPattern {
    class Test {
        // Anything that will be cached is flyweight.
        // Types of tea here will be flyweights.
        class KarakTea {
        }

        // Acts as a factory and saves the tea
        class TeaMaker {
            private Dictionary<string, KarakTea> mAvailableTea = new Dictionary<string, KarakTea>();

            public KarakTea Make(string preference) {
                if (!mAvailableTea.ContainsKey(preference)) {
                    mAvailableTea[preference] = new KarakTea();
                }

                return mAvailableTea[preference];
            }
        }

        class TeaShop {
            private Dictionary<int, KarakTea> mOrders = new Dictionary<int, KarakTea>();
            private readonly TeaMaker mTeaMaker;

            public TeaShop(TeaMaker teaMaker) {
                mTeaMaker = teaMaker ?? throw new ArgumentNullException("teaMaker", "teaMaker cannot be null");
            }

            public void TakeOrder(string teaType, int table) {
                mOrders[table] = mTeaMaker.Make(teaType);
            }

            public void Serve() {
                foreach (var table in mOrders.Keys) {
                    Console.WriteLine("Serving Tea to table # {0}", table);
                }
            }
        }
        public static void Run() {
            var teaMaker = new TeaMaker();
            var teaShop = new TeaShop(teaMaker);

            teaShop.TakeOrder("less sugar", 1);
            teaShop.TakeOrder("more milk", 2);
            teaShop.TakeOrder("without sugar", 5);

            teaShop.Serve();
            Console.ReadLine();
        }
    }
}


namespace ProxyPattern {
    interface IDoor {
        void Open();
        void Close();
    }

    class LabDoor : IDoor {
        public void Close() {
            Console.WriteLine("Closing lab door");
        }

        public void Open() {
            Console.WriteLine("Opening lab door");
        }
    }

    class SecuredDoor {
        private IDoor mDoor;

        public SecuredDoor(IDoor door) {
            mDoor = door ?? throw new ArgumentNullException("door", "door can not be null");
        }

        public void Open(string password) {
            if (Authenticate(password)) {
                mDoor.Open();
            }
            else {
                Console.WriteLine("Big no! It ain't possible.");
            }
        }

        private bool Authenticate(string password) {
            return password == "$ecr@t" ? true : false;
        }

        public void Close() {
            mDoor.Close();
        }
    }
    class Test {
        public static void Run() {
            var door = new SecuredDoor(new LabDoor());
            door.Open("invalid"); // Big no! It ain't possible.

            door.Open("$ecr@t"); // Opening lab door
            door.Close(); // Closing lab door

            Console.ReadLine();
        }
    }
}


namespace ChainOfResponsibilityPattern {
    abstract class Account {
        private Account mSuccessor;
        protected decimal mBalance;

        public void SetNext(Account account) {
            mSuccessor = account;
        }

        public void Pay(decimal amountTopay) {
            if (CanPay(amountTopay)) {
                Console.WriteLine("Paid {0:c} using {1}.", amountTopay, this.GetType().Name);
            }
            else if (this.mSuccessor != null) {
                Console.WriteLine("Cannot pay using {0}. Proceeding..", this.GetType().Name);
                mSuccessor.Pay(amountTopay);
            }
            else {
                throw new Exception("None of the accounts have enough balance");
            }
        }
        private bool CanPay(decimal amount) {
            return mBalance >= amount ? true : false;
        }
    }

    class Bank : Account {
        public Bank(decimal balance) {
            this.mBalance = balance;
        }
    }

    class Paypal : Account {
        public Paypal(decimal balance) {
            this.mBalance = balance;
        }
    }

    class Bitcoin : Account {
        public Bitcoin(decimal balance) {
            this.mBalance = balance;
        }
    }
    class Test {
        public static void Run() {
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

            Console.ReadLine();
        }
    }
}


namespace CommandPattern {
    class Test {
        // Receiver
        class Bulb {
            public void TurnOn() {
                Console.WriteLine("Bulb has been lit");
            }

            public void TurnOff() {
                Console.WriteLine("Darkness!");
            }
        }

        interface ICommand {
            void Execute();
            void Undo();
            void Redo();
        }

        // Command
        class TurnOn : ICommand {
            private Bulb mBulb;

            public TurnOn(Bulb bulb) {
                mBulb = bulb ?? throw new ArgumentNullException("Bulb", "Bulb cannot be null");
            }

            public void Execute() {
                mBulb.TurnOn();
            }

            public void Undo() {
                mBulb.TurnOff();
            }

            public void Redo() {
                Execute();
            }
        }

        class TurnOff : ICommand {
            private Bulb mBulb;

            public TurnOff(Bulb bulb) {
                mBulb = bulb ?? throw new ArgumentNullException("Bulb", "Bulb cannot be null");
            }

            public void Execute() {
                mBulb.TurnOff();
            }

            public void Undo() {
                mBulb.TurnOn();
            }

            public void Redo() {
                Execute();
            }
        }

        // Invoker
        class RemoteControl {
            public void Submit(ICommand command) {
                command.Execute();
            }
        }

        public static void Run() {
            var bulb = new Bulb();

            var turnOn = new TurnOn(bulb);
            var turnOff = new TurnOff(bulb);

            var remote = new RemoteControl();
            remote.Submit(turnOn); // Bulb has been lit!
            remote.Submit(turnOff); // Darkness!

            Console.ReadLine();
        }
    }
}


namespace IteratorPattern {
    class RadioStation {
        private float mFrequency;

        public RadioStation(float frequency) {
            mFrequency = frequency;
        }

        public float GetFrequecy() {
            return mFrequency;
        }

    }

    class StationList : IEnumerable<RadioStation> {
        List<RadioStation> mStations = new List<RadioStation>();

        public RadioStation this[int index] {
            get { return mStations[index]; }
            set { mStations.Insert(index, value); }
        }

        public void Add(RadioStation station) {
            mStations.Add(station);
        }

        public void Remove(RadioStation station) {
            mStations.Remove(station);
        }

        public IEnumerator<RadioStation> GetEnumerator() {
            return this.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            //Use can switch to this internal collection if you do not want to transform
            return mStations.GetEnumerator();

            //use this if you want to transform the object before rendering
            //foreach (var x in mStations)
            //{
            //  yield return x;
            //}
        }
    }

    class Test {
        public static void Run() {
            var stations = new StationList();
            var station1 = new RadioStation(89);
            stations.Add(station1);

            var station2 = new RadioStation(101);
            stations.Add(station2);

            var station3 = new RadioStation(102);
            stations.Add(station3);

            foreach (var x in stations) {
                Console.Write(x.GetFrequecy());
            }

            var q = stations.Where(x => x.GetFrequecy() == 89).FirstOrDefault();
            Console.WriteLine(q.GetFrequecy());

            Console.ReadLine();
        }
    }
}


namespace MediatorPattern {
    interface IChatRoomMediator {
        void ShowMessage(User user, string message);
    }

    //Mediator
    class ChatRoom : IChatRoomMediator {
        public void ShowMessage(User user, string message) {
            Console.WriteLine("{0} [{1}]:{2}", DateTime.Now.ToString("MMMM dd, H:mm"), user.GetName(), message);
        }
    }

    class User {
        private string mName;
        private IChatRoomMediator mChatRoom;

        public User(string name, IChatRoomMediator chatroom) {
            mChatRoom = chatroom;
            mName = name;
        }

        public string GetName() {
            return mName;
        }

        public void Send(string message) {
            mChatRoom.ShowMessage(this, message);
        }
    }


    class Test {
        public static void Run() {
            var mediator = new ChatRoom();

            var john = new User("John", mediator);
            var jane = new User("Jane", mediator);

            john.Send("Hi there!");
            jane.Send("Hey!");

            //April 14, 20:05[John]:Hi there!
            //April 14, 20:05[Jane]:Hey!

            Console.ReadLine();
        }
    }
}


namespace MementoPattern {
    class EditorMemento {
        private string mContent;

        public EditorMemento(string content) {
            mContent = content;
        }

        public string Content {
            get {
                return mContent;
            }
        }
    }

    class Editor {

        private string mContent = string.Empty;
        private EditorMemento memento;

        public Editor() {
            memento = new EditorMemento(string.Empty);
        }

        public void Type(string words) {
            mContent = String.Concat(mContent, " ", words);
        }

        public string Content {
            get {
                return mContent;
            }
        }

        public void Save() {
            memento = new EditorMemento(mContent);
        }

        public void Restore() {
            mContent = memento.Content;
        }
    }


    class Test {
        public static void Run() {
            var editor = new Editor();

            //Type some stuff
            editor.Type("This is the first sentence.");
            editor.Type("This is second.");

            // Save the state to restore to : This is the first sentence. This is second.
            editor.Save();

            //Type some more
            editor.Type("This is thrid.");

            //Output the content
            Console.WriteLine(editor.Content); // This is the first sentence. This is second. This is third.

            //Restoring to last saved state
            editor.Restore();

            Console.Write(editor.Content); // This is the first sentence. This is second

            Console.ReadLine();
        }
    }
}


namespace ObserverPattern {
    class JobPost {
        public string Title { get; private set; }

        public JobPost(string title) {
            Title = title;
        }
    }
    class JobSeeker : IObserver<JobPost> {
        public string Name { get; private set; }

        public JobSeeker(string name) {
            Name = name;
        }

        //Method is not being called by JobPostings class currently
        public void OnCompleted() {
            //No Implementation
        }

        //Method is not being called by JobPostings class currently
        public void OnError(Exception error) {
            //No Implementation
        }

        public void OnNext(JobPost value) {
            Console.WriteLine("Hi {0} ! New job posted: {1}", Name, value.Title);
        }
    }

    class JobPostings : IObservable<JobPost> {
        private List<IObserver<JobPost>> mObservers;
        private List<JobPost> mJobPostings;

        public JobPostings() {
            mObservers = new List<IObserver<JobPost>>();
            mJobPostings = new List<JobPost>();
        }

        public IDisposable Subscribe(IObserver<JobPost> observer) {
            // Check whether observer is already registered. If not, add it
            if (!mObservers.Contains(observer)) {
                mObservers.Add(observer);
            }
            return new Unsubscriber<JobPost>(mObservers, observer);
        }

        private void Notify(JobPost jobPost) {
            foreach (var observer in mObservers) {
                observer.OnNext(jobPost);
            }
        }

        public void AddJob(JobPost jobPost) {
            mJobPostings.Add(jobPost);
            Notify(jobPost);
        }

    }

    internal class Unsubscriber<JobPost> : IDisposable {
        private List<IObserver<JobPost>> mObservers;
        private IObserver<JobPost> mObserver;

        internal Unsubscriber(List<IObserver<JobPost>> observers, IObserver<JobPost> observer) {
            this.mObservers = observers;
            this.mObserver = observer;
        }

        public void Dispose() {
            if (mObservers.Contains(mObserver))
                mObservers.Remove(mObserver);
        }
    }


    class Test {
        public static void Run() {
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
        }
    }
}


namespace VisitorPattern {
    // Visitee
    interface IAnimal {
        void Accept(IAnimalOperation operation);
    }

    // Visitor
    interface IAnimalOperation {
        void VisitMonkey(Monkey monkey);
        void VisitLion(Lion lion);
        void VisitDolphin(Dolphin dolphin);
    }

    class Monkey : IAnimal {
        public void Shout() {
            Console.WriteLine("Oooh o aa aa!");
        }

        public void Accept(IAnimalOperation operation) {
            operation.VisitMonkey(this);
        }
    }

    class Lion : IAnimal {
        public void Roar() {
            Console.WriteLine("Roaar!");
        }

        public void Accept(IAnimalOperation operation) {
            operation.VisitLion(this);
        }
    }

    class Dolphin : IAnimal {
        public void Speak() {
            Console.WriteLine("Tuut tittu tuutt!");
        }

        public void Accept(IAnimalOperation operation) {
            operation.VisitDolphin(this);
        }
    }

    class Speak : IAnimalOperation {
        public void VisitDolphin(Dolphin dolphin) {
            dolphin.Speak();
        }

        public void VisitLion(Lion lion) {
            lion.Roar();
        }

        public void VisitMonkey(Monkey monkey) {
            monkey.Shout();
        }
    }

    class Jump : IAnimalOperation {
        public void VisitDolphin(Dolphin dolphin) {
            Console.WriteLine("Walked on water a little and disappeared!");
        }

        public void VisitLion(Lion lion) {
            Console.WriteLine("Jumped 7 feet! Back on the ground!");
        }

        public void VisitMonkey(Monkey monkey) {
            Console.WriteLine("Jumped 20 feet high! on to the tree!");
        }
    }


    class Test {
        public static void Run() {
            var monkey = new Monkey();
            var lion = new Lion();
            var dolphin = new Dolphin();

            var speak = new Speak();

            monkey.Accept(speak);    // Ooh oo aa aa!    
            lion.Accept(speak);      // Roaaar!
            dolphin.Accept(speak);   // Tuut tutt tuutt!

            var jump = new Jump();

            monkey.Accept(speak);   // Ooh oo aa aa!
            monkey.Accept(jump);    // Jumped 20 feet high! on to the tree!

            lion.Accept(speak);     // Roaaar!
            lion.Accept(jump);      // Jumped 7 feet! Back on the ground!

            dolphin.Accept(speak);  // Tuut tutt tuutt!
            dolphin.Accept(jump);   // Walked on water a little and disappeared

            Console.ReadLine();
        }
    }
}


namespace StrategyPattern {
    interface ISortStrategy {
        List<int> Sort(List<int> dataset);
    }

    class BubbleSortStrategy : ISortStrategy {
        public List<int> Sort(List<int> dataset) {
            Console.WriteLine("Sorting using Bubble Sort !");
            return dataset;
        }
    }

    class QuickSortStrategy : ISortStrategy {
        public List<int> Sort(List<int> dataset) {
            Console.WriteLine("Sorting using Quick Sort !");
            return dataset;
        }
    }

    class Sorter {
        private readonly ISortStrategy mSorter;

        public Sorter(ISortStrategy sorter) {
            mSorter = sorter;
        }

        public List<int> Sort(List<int> unSortedList) {
            return mSorter.Sort(unSortedList);
        }
    }

    class Test {
        public static void Run() {
            var unSortedList = new List<int> { 1, 10, 2, 16, 19 };

            var sorter = new Sorter(new QuickSortStrategy());
            sorter.Sort(unSortedList); // // Output : Sorting using Bubble Sort !

            sorter = new Sorter(new QuickSortStrategy());
            sorter.Sort(unSortedList); // // Output : Sorting using Quick Sort !

            Console.ReadLine();
        }
    }
}


namespace StatePattern {
    interface IWritingState {

        void Write(string words);

    }

    class UpperCase : IWritingState {
        public void Write(string words) {
            Console.WriteLine(words.ToUpper());
        }
    }

    class LowerCase : IWritingState {
        public void Write(string words) {
            Console.WriteLine(words.ToLower());
        }
    }

    class DefaultText : IWritingState {
        public void Write(string words) {
            Console.WriteLine(words);
        }
    }

    class TextEditor {

        private IWritingState mState;

        public TextEditor() {
            mState = new DefaultText();
        }

        public void SetState(IWritingState state) {
            mState = state;
        }

        public void Type(string words) {
            mState.Write(words);
        }

    }

    class Test {
        public static void Run() {
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

            Console.ReadLine();
        }
    }
}


namespace TemplateMethodPattern {
    abstract class Builder {
        // Template method
        public void Build() {
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

    class AndroidBuilder : Builder {
        public override void Assemble() {
            Console.WriteLine("Assembling the android build");
        }

        public override void Deploy() {
            Console.WriteLine("Deploying android build to server");
        }

        public override void Lint() {
            Console.WriteLine("Linting the android code");
        }

        public override void Test() {
            Console.WriteLine("Running android tests");
        }
    }


    class IosBuilder : Builder {
        public override void Assemble() {
            Console.WriteLine("Assembling the ios build");
        }

        public override void Deploy() {
            Console.WriteLine("Deploying ios build to server");
        }

        public override void Lint() {
            Console.WriteLine("Linting the ios code");
        }

        public override void Test() {
            Console.WriteLine("Running ios tests");
        }
    }

    class Test {
        public static void Run() {
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

            Console.ReadLine();
        }
    }
}
