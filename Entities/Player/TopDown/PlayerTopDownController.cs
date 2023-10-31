using Godot;
using Godot.Collections;

public partial class PlayerTopDownController : CharacterBody2D{
	//signals
	[Signal]
	public delegate void ItemAddedEventHandler(Item item);

	//variabls
	[ExportCategory("Movement Variables")]
	[Export] 
	public float speed = 300.0f;

	//nodes
	private Area2D interactArea;

    public override void _Ready(){
		interactArea = GetNode<Area2D>("InteractArea");
    }

	public override void _Process(double delta){
		this.LookForInteractive();
	}

	public override void _PhysicsProcess(double delta){
		this.MovingProcess(delta);
	}

    public override void _Input(InputEvent @event){
		if(@event.IsActionPressed("action_right")){
			// Resource dialogue = GD.Load<Resource>("res://Dialogues/test1.dialogue");
			// DialogueManager.ShowExampleDialogueBalloon(dialogue, "cop_dialogue");
		}
    }

	private void MovingProcess(double delta){
		Vector2 direction = Input.GetVector("input_left", "input_right", "input_up", "input_down").Normalized();

		Velocity = direction * speed;
		MoveAndSlide();
	}

	private void LookForInteractive(){
		Array<Area2D> areas = interactArea.GetOverlappingAreas();
		if(Input.IsActionJustPressed("action_left") && areas.Count > 0){
			// foreach(Area2D area in areas){
				Area2D area = areas[0];
				GD.Print("area name: " + area.Name);
				if(area is Item){ 
					GD.Print("this area is Item");
					Item item = area as Item;
					if(!item.isNoted){
						// GetNode<NoteBook>("/root/NoteBook").AddNote(item);
						GD.Print("Sending signal...");
						EmitSignal(SignalName.ItemAdded, item);
						item.isNoted = true;
					}else
						GD.Print("Already noted!");
				}
			// }
		}
	}
}
