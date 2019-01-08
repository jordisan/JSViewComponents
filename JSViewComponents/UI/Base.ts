const LOADINGCLASS = "loading";

/** Base class for all components */
class Base {
    protected id: string;
    protected dataUrl: URL;
    protected el: HTMLElement;

    constructor(id: string, dataUrl: string) {
        this.id = id;
        this.dataUrl = new URL(dataUrl);
        this.el = document.getElementById(this.id);
        this.initialize();
    }

    /** Refresh component content from server */
    public getFromServer = (params: { [paramName: string]: string }) => {
        var url: URL = this.dataUrl;
        Object.keys(params).forEach(key => url.searchParams.append(key, params[key]))
        this.el.classList.add(LOADINGCLASS);
        fetch(
            url.toString(),
            {
                method: "GET",
                headers: {
                    "Content-Type": "text/html"
                }
            }
        ).then(response => {
            this.el.classList.remove(LOADINGCLASS);
            if (!response.ok) {
                throw new Error(response.statusText);
            } else {
                response.text().then((text) => {
                    this.el.innerHTML = text;
                    this.initialize();
                });
            }
        })
    };

    /** Initializations (listeners, etc.); to be implemented by every component type */
    protected initialize() { }
}