var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    }
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var LOADINGCLASS = "loading";
/** Base class for all components */
var Base = /** @class */ (function () {
    function Base(id, dataUrl) {
        var _this = this;
        /** Refresh component content from server */
        this.getFromServer = function (params) {
            var url = _this.dataUrl;
            Object.keys(params).forEach(function (key) { return url.searchParams.set(key, params[key]); });
            _this.el.classList.add(LOADINGCLASS);
            fetch(url.toString(), {
                method: "GET",
                headers: {
                    "Content-Type": "text/html"
                }
            }).then(function (response) {
                _this.el.classList.remove(LOADINGCLASS);
                if (!response.ok) {
                    throw new Error(response.statusText);
                }
                else {
                    response.text().then(function (text) {
                        _this.el.innerHTML = text;
                        _this.initialize();
                    });
                }
            });
        };
        this.id = id;
        this.dataUrl = new URL(dataUrl);
        this.el = document.getElementById(this.id);
        this.initialize();
    }
    /** Initializations (listeners, etc.); to be implemented by every component type */
    Base.prototype.initialize = function () { };
    return Base;
}());
var Table = /** @class */ (function (_super) {
    __extends(Table, _super);
    function Table() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    Table.prototype.initialize = function () {
        var _this = this;
        // click on title to get sorted data
        this.el.querySelectorAll('th.sortable').forEach(function (header) { return header.addEventListener("click", function (event) { _this.getFromServer({ sortCriteria: event.target.dataset.internalName + ' ASC' }); }); });
    };
    return Table;
}(Base));
//# sourceMappingURL=JSViewComponents.js.map