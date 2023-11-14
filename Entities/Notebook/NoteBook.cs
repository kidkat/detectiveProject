using Godot;
using Godot.Collections;

public partial class NoteBook : Control{
	[ExportCategory("Notes List")]
	[Export]
	private Array<Item> _itemList;
    [Export]
    private Array<Person> _presonList;
	[ExportCategory("")]
    [Export]
    private NodePath InteractiveMenuControllerNodePath;

    public override void _Ready(){ 
        _itemList = new();
        _presonList = new();
        this.Hide();
    }

    public override void _Input(InputEvent @event){
        if(@event.IsActionPressed("noteBook_action")){
			this.OpenCloseNoteBook();
		}
    }

	private void CheckId(long id){
        GD.Print("Got signal");
    }
	
	public void AddNote(Item item){
		_itemList.Add(item);
		PopUpMessage("Note Added!", "Found item: " + item.Name);
	}

	public void RemoveNote(int num){
		_itemList.RemoveAt(num);
	}
	
	private void PopUpMessage(string title, string message){
		AcceptDialog dialog = new AcceptDialog();
		dialog.DialogText = message;
		dialog.Title = title;
		AddChild(dialog);
		dialog.PopupCentered();
	}

	public void OpenCloseNoteBook(){
		if(!this.Visible){
			GD.Print("NoteBook Opened!");
			this.Show();
		}else{
			GD.Print("NoteBook Closed!");
			this.Hide();
		}
	}
}
