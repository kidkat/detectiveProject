using Godot;
using Godot.Collections;

public partial class NoteBook : Control{
	public enum Notes { ITEM, PERSON, EVENT, LOCATION}	
	[Signal]
	public delegate void NoteBookOpenedEventHandler();
	[Signal]
	public delegate void NoteBookClosedEventHandler();

	[ExportCategory("Notes List")]
	[Export]
	private Array<Item> _itemList;
    [Export]
    private Array<Person> _presonList;
	// [ExportCategory("NoteBook Variables")]
    // [Export]
    // private NodePath _interactiveMenuControllerNodePath;

    public override void _Ready(){ 
        _itemList = new();
        _presonList = new();
        // this.Hide();

        // GetNode<InteractiveMenuController>(_interactiveMenuControllerNodePath).ItemAdded += (item) => this.AddNoteItem(item);
        // GetNode<InteractiveMenuController>(_interactiveMenuControllerNodePath).PersonAdded += (person) => this.AddNotePerson(person);
    }

    public override void _Input(InputEvent @event){
        if(@event.IsActionPressed("noteBook_action")){
			this.OpenCloseNoteBook();
		}
    }
	
	private void AddNoteItem(Item item){
		_itemList.Add(item);
        GD.Print("Note Added! Item Added: " + item.Name);
        PopUpMessage("Note Added!", "Found item: " + item.Name);
    }

	private void AddNotePerson(Person person){
        _presonList.Add(person);
        GD.Print("Note Added! Person Added: " + person.Name);
    }
	
	private void PopUpMessage(string title, string message){
		AcceptDialog dialog = new AcceptDialog();
		dialog.DialogText = message;
		dialog.Title = title;
		AddChild(dialog);
		dialog.PopupCentered();
	}

	private void OpenCloseNoteBook(){
		if(!this.Visible){
			GD.Print("NoteBook Opened!");
			this.Show();
            EmitSignal(SignalName.NoteBookOpened);
        }else{
			GD.Print("NoteBook Closed!");
			this.Hide();
            EmitSignal(SignalName.NoteBookClosed);
        }
	}

	public Array<Item> GetItems(){
        return _itemList;
    }

	public Array<Person> GetPeople(){
        return _presonList;
    }
}
