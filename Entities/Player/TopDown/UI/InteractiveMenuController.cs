using Godot;
using Godot.Collections;

public partial class InteractiveMenuController : Control{
    [ExportCategory("Interactive Menu Variables")]
    [Export]
    private NodePath _playerTopDownNodePath;
    [Export]
    private string _interactiveAreaNodePath;
    [Export]
    private NodePath _boxContainerNodePath;
    
    private VBoxContainer _boxContainer;


    public override void _Ready(){
        this.Hide();
        _boxContainer = GetNode<VBoxContainer>(_boxContainerNodePath);
        GetNode<InteractiveAreaController>(_playerTopDownNodePath.ToString() + "/" + _interactiveAreaNodePath).Interacted += (areaList, bodyList) => this.PopupMenu(areaList, bodyList);
    }

    private void PopupMenu(Array<Area2D> interactAreaList, Array<Node2D> interactBodyList){
        if(this.Visible)
            return;

        this.Show();
        if(interactAreaList.Count > 0){
            this.SetUpInteractAreas(interactAreaList);
        }

        if(interactBodyList.Count > 0){
            this.SetUpInteractBodies(interactBodyList);
        }

        this.SetUpCloseButton();
    }

    private void SetUpInteractAreas(Array<Area2D> interactAreaList){
        Label label = new();
        label.Name = "Items";
        label.Text = "Items";
        label.HorizontalAlignment = HorizontalAlignment.Center;
        _boxContainer.AddChild(label);
        foreach(Area2D area in interactAreaList){
            MenuButton menuButton = new();
            menuButton.Name = area.Name;
            menuButton.Text = area.Name;
            _boxContainer.AddChild(menuButton);

            PopupMenu areaPopupMenu = menuButton.GetPopup();
            areaPopupMenu.Name = area.Name;
            areaPopupMenu.AddItem("Node it");
        }
    }

    private void SetUpInteractBodies(Array<Node2D> interactBodyList){
        Label label = new();
        label.Name = "Persons";
        label.Text = "Persons";
        label.HorizontalAlignment = HorizontalAlignment.Center;
        _boxContainer.AddChild(label);
        foreach(Node2D body in interactBodyList){
            MenuButton menuButton = new();
            menuButton.Name = body.Name;
            menuButton.Text = body.Name;
            _boxContainer.AddChild(menuButton);

            PopupMenu bodyPopupMenu = menuButton.GetPopup();
            bodyPopupMenu.Name = body.Name;
            bodyPopupMenu.AddItem("Talk!");
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
}
