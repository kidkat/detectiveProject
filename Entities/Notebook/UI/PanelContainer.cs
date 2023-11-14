using System.Reflection.Metadata.Ecma335;
using Godot;

public partial class PanelContainer : Godot.PanelContainer{
	enum Pages{ PEOPLE, EVENTS, ITEMS, LOCATIONS }

	[ExportCategory("Buttons")]
	[Export]
	private Button _peopleButton;
	[Export]
	private Button _eventsButton;
	[Export]
	private Button _itemsButton;
	[Export]
	private Button _locationsButton;

	[ExportCategory("Controls")]
	[Export]
	private Control _mainPage;
	[Export]
	private Control _peoplePage;
	[Export]
	private Control _eventsPage;
	[Export]
	private Control _itemsPage;
	[Export]
	private Control _locationsPage;
	
    [ExportCategory("Actions")]
    [Export]
    private StringName _actionNoteBookBack;

    public override void _Ready(){
		this.DisableAllPages();
		_mainPage.Show();
		_peopleButton.Pressed += () => this.TurnPage(Pages.PEOPLE);
		_eventsButton.Pressed += () => this.TurnPage(Pages.EVENTS);
		_itemsButton.Pressed += () => this.TurnPage(Pages.ITEMS);
		_locationsButton.Pressed += () => this.TurnPage(Pages.LOCATIONS);
	}

    public override void _Input(InputEvent @event){
        if(@event.IsActionPressed(_actionNoteBookBack)){
			this.DisableAllPages();
			_mainPage.Show();
		}
    }
    
	private void TurnPage(Pages page){
		this.DisableAllPages();
		switch(page){
			case Pages.PEOPLE:
				GD.Print("people button pressed!");
				_peoplePage.Show();
				break;
			case Pages.ITEMS:
				GD.Print("items button pressed!");
				_itemsPage.Show();
				break;
			case Pages.LOCATIONS:
				GD.Print("locations button pressed!");
				_locationsPage.Show();
				break;
			case Pages.EVENTS:
				GD.Print("events button pressed!");
				_eventsPage.Show();
				break;
		}
	}

	private void DisableAllPages(){
		_mainPage.Hide();
		_peoplePage.Hide();
		_itemsPage.Hide();
		_locationsPage.Hide();
		_eventsPage.Hide();
	}
}
