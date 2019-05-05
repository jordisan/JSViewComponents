declare const LOADINGCLASS = "loading";
/** Base class for all components */
declare class Base {
    protected id: string;
    protected dataUrl: URL;
    protected el: HTMLElement;
    constructor(id: string, dataUrl: string);
    /** Refresh component content from server */
    getFromServer: (params: {
        [paramName: string]: string;
    }) => void;
    /** Initializations (listeners, etc.); to be implemented by every component type */
    protected initialize(): void;
}
declare class SingleItem extends Base {
    protected initialize(): void;
}
declare class Table extends Base {
    protected initialize(): void;
}
