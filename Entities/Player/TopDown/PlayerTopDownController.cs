using Godot;

public partial class PlayerTopDownController : CharacterBody2D{
    [Signal]
    public delegate void ItemAddedEventHandler(Item item);

    [ExportCategory("Movement Variables")]
    [Export]
    private float _speed = 300.0f;
    [Export]
    private bool _canMove = true;
    
    [ExportCategory("Movement Actions")]
    [Export]
    private StringName _actionNameForInputLeft;
    [Export]
    private StringName _actionNameForInputRight;
    [Export]
    private StringName _actionNameForInputUp;
    [Export]
    private StringName _actionNameForInputDown;

    [ExportCategory("Paths of Nodes")]
    [Export]
    private NodePath _interactionAreaNodePath;
    [Export]
    private NodePath _interactiveMenuNodePath;


    public override void _Ready(){
        GetNode<InteractiveAreaController>(_interactionAreaNodePath).Interacted += (areaList, bodyList) => this.SetAbilityToMove(false);
        GetNode<InteractiveMenuController>(_interactiveMenuNodePath).Hidden += () => this.SetAbilityToMove(true);
    }

	public override void _PhysicsProcess(double delta){
		this.MovingProcess(delta);
	}

	private void MovingProcess(double delta){
        if (_canMove){
            Vector2 direction = Input.GetVector(_actionNameForInputLeft, _actionNameForInputRight, _actionNameForInputUp, _actionNameForInputDown).Normalized();

            Velocity = direction * _speed;
            MoveAndSlide();
        }
    }

	private void SetAbilityToMove(bool canMove){
        _canMove = canMove;
    }
}
