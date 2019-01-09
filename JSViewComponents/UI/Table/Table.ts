class Table extends Base {

    protected initialize() {
        // click on title to get sorted data
        this.el.querySelectorAll('th.sortable').forEach((header) => header.addEventListener(
            "click", (event: Event) => { this.getFromServer({ sortCriteria: (<HTMLElement>event.target).dataset.internalName + ' ASC'}) }
        ));
    }
}