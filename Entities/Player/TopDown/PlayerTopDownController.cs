using System.Linq;
using Godot;
using Godot.Collections;

public partial class PlayerTopDownController : CharacterBody2D{
	
	[Signal]
	private delegate void Note_Added();

	[ExportCategory("Movement Variables")]
	[Export] 
	public float speed = 300.0f;

    public override void _Process(double delta){
        this.LookForInteractive();
    }

	public override void _PhysicsProcess(double delta){
		this.MovingProcess(delta);
		
	}

	private void MovingProcess(double delta){
		Vector2 direction = Input.GetVector("input_left", "input_right", "input_up", "input_down").Normalized();

		Velocity = direction * speed;
		MoveAndSlide();
	}

	public void LookForInteractive(){
		Array<Area2D> areas =  GetNode<Area2D>("InteractArea").GetOverlappingAreas();
		if(Input.IsActionJustPressed("action_left") && areas.Count > 0){
			// foreach(Area2D area in areas){
				Area2D area = areas[0];
				GD.Print("area name: " + area.Name);
				if(area is Item){ 
					GD.Print("this area is Item");
					Item item = area as Item;
				}
			// }
		}
	}
}
