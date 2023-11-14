using Godot;
using Godot.Collections;

public partial class NoteBook : Control{
	[ExportCategory("Notes List")]
	[Export]
	public Array<Item> notes;
	[Export]
	private NodePath playerTopDownContollerNodePath;
    [Export]
    private NodePath InteractiveMenuControllerNodePath;
    private BoxContainer boxContainer;

    public override void _Ready(){ 
        // notes = new Array<Item>();
		this.Hide();
        PlayerTopDownController playerTopDownController = GetNode<PlayerTopDownController>(playerTopDownContollerNodePath);
		// if(interactiveMenuController != null)
        //     interactiveMenuController.IdPressed += (id) => CheckId(id);
        // PlayerTopDownController playerTopDownController = GetNodeOrNull<PlayerTopDownController>(playerTopDownContollerNodePath);
        // if(playerTopDownController!= null)
        // 	playerTopDownController.ItemAdded += (item) => AddNote(item);
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
		notes.Add(item);
		PopUpMessage("Note Added!", "Found item: " + item.Name);
        // Button button = new(){
        //     Text = item.Name
        // };
        // boxContainer.AddChild(button);
	}

	public void RemoveNote(int num){
		notes.RemoveAt(num);
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
