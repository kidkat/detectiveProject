using System.Reflection.Metadata.Ecma335;
using Godot;

public partial class PanelContainer : Godot.PanelContainer{
	//node paths
	//nodes
	//buttons
	[Export]
	private Button peopleButton;
	[Export]
	private Button cluesButton;
	[Export]
	private Button locationsButton;
	[Export]
	private Button objectivesButton;
	//control pages
	[Export]
	private Control mainPage;
	[Export]
	private Control peoplePage;
	[Export]
	private Control cluesPage;
	[Export]
	private Control locationsPage;
	[Export]
	private Control objectivesPage;

	public override void _Ready(){
		this.disableAllPages();
		mainPage.Show();
		peopleButton.Pressed += () => turnPage("people");
		cluesButton.Pressed += () => turnPage("clues");
		locationsButton.Pressed += () => turnPage("locations");
		objectivesButton.Pressed += () => turnPage("objectives");
	}

    public override void _Input(InputEvent @event){
        if(@event.IsActionPressed("noteBook_back")){
			this.disableAllPages();
			mainPage.Show();
		}
    }
    
	private void turnPage(string page){
		this.disableAllPages();
		switch(page){
			case "people":
				GD.Print("people button pressed!");
				peoplePage.Show();
				break;
			case "clues":
				GD.Print("clues button pressed!");
				cluesPage.Show();
				break;
			case "locations":
				GD.Print("locations button pressed!");
				locationsPage.Show();
				break;
			case "objectives":
				GD.Print("objectives button pressed!");
				objectivesPage.Show();
				break;
		}
	}

	private void disableAllPages(){
		mainPage.Hide();
		peoplePage.Hide();
		cluesPage.Hide();
		locationsPage.Hide();
		objectivesPage.Hide();
	}
}
