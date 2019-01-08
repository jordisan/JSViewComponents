class Table extends Base {

    protected initialize() {
        // click on title to get sorted data
        this.el.querySelectorAll('th').forEach((header) => header.addEventListener(
            "click", (event: Event) => { this.getFromServer({sortBy: event.target.toString()}) }
        ));
    }
}