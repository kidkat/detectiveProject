using Godot;
using Godot.Collections;

public partial class InteractiveMenuController : Control{
    [Signal]
    public delegate void ItemAddedEventHandler(Item item);
    [Signal]
    public delegate void PersonAddedEventHandler(Person person);

    [ExportCategory("Interactive Menu Variables")]
    [Export]
    private NodePath _playerTopDownNodePath;
    [Export]
    private string _interactiveAreaNodePath;
    [Export]
    private NodePath _boxContainerNodePath;

    private VBoxContainer _boxContainer;

    private Dictionary<long, Item> _itemsDictionary;
    private Dictionary<long, Node2D> _personDictionary;
    private int _indexCounter;

    public override void _Ready(){
        this.Hide();
        _itemsDictionary = new();
        _personDictionary = new();
        _indexCounter = 0;
        _boxContainer = GetNode<VBoxContainer>(_boxContainerNodePath);
        GetNode<InteractiveAreaController>(_playerTopDownNodePath + "/" + _interactiveAreaNodePath).Interacted += (itemList, personList) => this.PopupMenu(itemList, personList);
    }

    private void PopupMenu(Array<Item> interactItemList, Array<Person> interactPersonList){
        if(this.Visible)
            return;

        this.Show();
        if(interactItemList.Count > 0){
            this.SetUpInteractItems(interactItemList);
        }

        if(interactPersonList.Count > 0){
            this.SetUpInteractPersons(interactPersonList);
        }

        this.SetUpCloseButton();
    }

    private void SetUpInteractItems(Array<Item> interactItemList){
        Label label = new();
        label.Name = "Items";
        label.Text = "Items";
        label.HorizontalAlignment = HorizontalAlignment.Center;
        _boxContainer.AddChild(label);
        foreach(Item item in interactItemList){
            MenuButton menuButton = new();
            menuButton.Name = item.Name;
            menuButton.Text = item.Name;
            _boxContainer.AddChild(menuButton);

            PopupMenu itemPopupMenu = menuButton.GetPopup();
            itemPopupMenu.Name = item.Name;
            itemPopupMenu.AddItem("Node it", _indexCounter);
            _itemsDictionary.Add(_indexCounter, item);
            _indexCounter++;
            itemPopupMenu.IdPressed += (id) => this.IdPressed(id);
        }
    }

    private void SetUpInteractPersons(Array<Person> interactBodyList){
        Label label = new();
        label.Name = "Persons";
        label.Text = "Persons";
        label.HorizontalAlignment = HorizontalAlignment.Center;
        _boxContainer.AddChild(label);
        foreach(Person person in interactBodyList){
            MenuButton menuButton = new();
            menuButton.Name = person.Name;
            menuButton.Text = person.Name;
            _boxContainer.AddChild(menuButton);

            PopupMenu personPopupMenu = menuButton.GetPopup();
            personPopupMenu.Name = person.Name;
            personPopupMenu.AddItem("Talk!", _indexCounter);
            _personDictionary.Add(_indexCounter, person);
            _indexCounter++;
            personPopupMenu.IdPressed += (id) => this.IdPressed(id);
        }
    }

    private void SetUpCloseButton(){
        Button closeButton = new();
        closeButton.Name = "Close";
        closeButton.Text = "Close";
        _boxContainer.AddChild(closeButton);
        closeButton.Pressed += () => this.CloseButtonPressed();
    }

    private void CloseButtonPressed(){
        this.Hide();
        //removing all content from boxContainer
        foreach(Node container in _boxContainer.GetChildren()){
            _boxContainer.RemoveChild(container);
        }
    }

    private void IdPressed(long id){
        if(_itemsDictionary.ContainsKey(id)){
            EmitSignal(SignalName.ItemAdded, _itemsDictionary[id]);
            this.CloseButtonPressed();
        }

        if(_personDictionary.ContainsKey(id)){
            EmitSignal(SignalName.PersonAdded, _personDictionary[id]);
            this.CloseButtonPressed();
        }
    }
}
