using Godot;
using Godot.Collections;

public partial class ItemsPage : Control{
    [Export]
    private NoteBook _noteBook;
    [Export]
    private BoxContainer _boxContainer;

    public override void _Ready(){
        // Array<Item> items = _noteBook.GetItems();
		// if(items.Count == 0){
        //     this.ShowEmpyPage();
		// }else{
        //     this.RefreshPage();
        // }
    }

    public void RefreshPage(){
        Array<Item> items = _noteBook.GetItems();
		if(items.Count > 0){
			foreach(Item item in items){
				Label itemLabel = new();
                itemLabel.Text = item.Name;
                itemLabel.HorizontalAlignment = HorizontalAlignment.Center;
                _boxContainer.AddChild(itemLabel);
            }
		}else{
            this.ShowEmpyPage();
        }
	}

	private void ShowEmpyPage(){
        Label label = new();
        label.Text = "No Items Found!";
        label.HorizontalAlignment = HorizontalAlignment.Center;
        _boxContainer.AddChild(label);
    }

	public void ClearThePage(){
        this.Hide();
        //removing all content from boxContainer
        foreach(Node node in _boxContainer.GetChildren()){
			if(node.Name != "PageTitle")
            	_boxContainer.RemoveChild(node);
        }
    }
}
