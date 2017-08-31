﻿! function (t, e) {
    "object" == typeof exports && "object" == typeof module ? module.exports = e(require("angular")) : "function" == typeof define && define.amd ? define(["angular"], e) : "object" == typeof exports ? exports["ng-table"] = e(require("angular")) : t["ng-table"] = e(t.angular)
}(this, function (t) {
    return function (t) {
        function e(r) {
            if (n[r]) return n[r].exports;
            var a = n[r] = {
                i: r,
                l: !1,
                exports: {}
            };
            return t[r].call(a.exports, a, a.exports, e), a.l = !0, a.exports
        }
        var n = {};
        return e.m = t, e.c = n, e.i = function (t) {
            return t
        }, e.d = function (t, e, n) {
            Object.defineProperty(t, e, {
                configurable: !1,
                enumerable: !0,
                get: n
            })
        }, e.n = function (t) {
            var n = t && t.__esModule ? function () {
                return t.default
            } : function () {
                return t
            };
            return e.d(n, "a", n), n
        }, e.o = function (t, e) {
            return Object.prototype.hasOwnProperty.call(t, e)
        }, e.p = "", e(e.s = 33)
    }(function (t) {
        for (var e in t)
            if (Object.prototype.hasOwnProperty.call(t, e)) switch (typeof t[e]) {
                case "function":
                    break;
                case "object":
                    t[e] = function (e) {
                        var n = e.slice(1),
                            r = t[e[0]];
                        return function (t, e, a) {
                            r.apply(this, [t, e, a].concat(n))
                        }
                    }(t[e]);
                    break;
                default:
                    t[e] = t[t[e]]
            }
        return t
    }([function (e, n) {
        e.exports = t
    }, function (t, e, n) {
        "use strict";

        function r(t) {
            for (var n in t) e.hasOwnProperty(n) || (e[n] = t[n])
        }
        var a = n(0),
            i = n(4),
            o = n(5),
            l = n(6),
            s = n(7),
            u = n(8),
            c = n(9),
            p = n(10),
            f = n(11),
            g = n(12),
            d = n(13),
            h = n(14),
            m = n(15),
            b = n(16),
            v = n(17);
        n(25), n(27), n(26), n(28), n(31), n(30), Object.defineProperty(e, "__esModule", {
            value: !0
        }), e.default = a.module("ngTable-browser", []).directive("ngTable", i.ngTable).factory("ngTableColumn", o.ngTableColumn).directive("ngTableColumnsBinding", l.ngTableColumnsBinding).controller("ngTableController", s.ngTableController).directive("ngTableDynamic", u.ngTableDynamic).provider("ngTableFilterConfig", c.ngTableFilterConfigProvider).directive("ngTableFilterRow", p.ngTableFilterRow).controller("ngTableFilterRowController", f.ngTableFilterRowController).directive("ngTableGroupRow", g.ngTableGroupRow).controller("ngTableGroupRowController", d.ngTableGroupRowController).directive("ngTablePagination", h.ngTablePagination).directive("ngTableSelectFilterDs", m.ngTableSelectFilterDs).directive("ngTableSorterRow", b.ngTableSorterRow).controller("ngTableSorterRowController", v.ngTableSorterRowController), r(n(18))
    }, function (t, e, n) {
        "use strict";

        function r(t) {
            for (var n in t) e.hasOwnProperty(n) || (e[n] = t[n])
        }
        var a = n(0),
            i = n(19),
            o = n(20),
            l = n(22),
            s = n(21);
        Object.defineProperty(e, "__esModule", {
            value: !0
        }), e.default = a.module("ngTable-core", []).provider("ngTableDefaultGetData", i.ngTableDefaultGetDataProvider).value("ngTableDefaults", o.ngTableDefaults).factory("NgTableParams", l.ngTableParamsFactory).factory("ngTableEventsChannel", s.ngTableEventsChannel), r(n(23))
    }, , function (t, e, n) {
        "use strict";

        function r(t, e) {
            return {
                restrict: "A",
                priority: 1001,
                scope: !0,
                controller: "ngTableController",
                compile: function (t) {
                    var n, r, i = [],
                        o = 0,
                        l = [];
                    if (a.forEach(t.find("tr"), function (t) {
                            l.push(a.element(t))
                    }), n = l.filter(function (t) {
                            return !t.hasClass("ng-table-group")
                    })[0], r = l.filter(function (t) {
                            return t.hasClass("ng-table-group")
                    })[0], n) return a.forEach(n.find("td"), function (t) {
                        var n = a.element(t);
                        if (!n.attr("ignore-cell") || "true" !== n.attr("ignore-cell")) {
                            var l = function (t) {
                                return n.attr("x-data-" + t) || n.attr("data-" + t) || n.attr(t)
                            },
                                s = function (t, e) {
                                    n.attr("x-data-" + t) ? n.attr("x-data-" + t, e) : n.attr("data" + t) ? n.attr("data" + t, e) : n.attr(t, e)
                                },
                                u = function (t) {
                                    var n = l(t);
                                    if (n) {
                                        var r, a = function (t) {
                                            return void 0 !== r ? r : e(n)(t)
                                        };
                                        return a.assign = function (t, a) {
                                            var i = e(n);
                                            i.assign ? i.assign(t.$parent, a) : r = a
                                        }, a
                                    }
                                },
                                c = l("title-alt") || l("title");
                            c && n.attr("data-title-text", "{{" + c + "}}"), i.push({
                                id: o++,
                                title: u("title"),
                                titleAlt: u("title-alt"),
                                headerTitle: u("header-title"),
                                sortable: u("sortable"),
                                "class": u("header-class"),
                                filter: u("filter"),
                                groupable: u("groupable"),
                                headerTemplateURL: u("header"),
                                filterData: u("filter-data"),
                                show: n.attr("ng-if") ? u("ng-if") : void 0
                            }), (r || n.attr("ng-if")) && s("ng-if", "$columns[" + (i.length - 1) + "].show(this)")
                        }
                    }),
                    function (t, e, n, r) {
                        t.$columns = i = r.buildColumns(i), r.setupBindingsToInternalScope(n.ngTable), r.loadFilterData(i), r.compileDirectiveTemplates()
                    }
                }
            }
        }
        var a = n(0);
        r.$inject = ["$q", "$parse"], e.ngTable = r
    }, function (t, e, n) {
        "use strict";

        function r() {
            function t(t, n, i) {
                var o = Object.create(t),
                    l = e();
                for (var s in l) void 0 === o[s] && (o[s] = l[s]), a.isFunction(o[s]) || ! function (e) {
                    var n = function a() {
                        return 1 !== arguments.length || r(arguments[0]) ? t[e] : void a.assign(null, arguments[0])
                    };
                    n.assign = function (n, r) {
                        t[e] = r
                    }, o[e] = n
                }(s),
                    function (e) {
                        var l = o[e];
                        o[e] = function () {
                            if (1 !== arguments.length || r(arguments[0])) {
                                var e = arguments[0] || n,
                                    s = Object.create(e);
                                return a.extend(s, {
                                    $column: o,
                                    $columns: i
                                }), l.call(t, s)
                            }
                            l.assign(null, arguments[0])
                        }, l.assign && (o[e].assign = l.assign)
                    }(s);
                return o
            }

            function e() {
                return {
                    "class": n(""),
                    filter: n(!1),
                    groupable: n(!1),
                    filterData: a.noop,
                    headerTemplateURL: n(!1),
                    headerTitle: n(""),
                    sortable: n(!1),
                    show: n(!0),
                    title: n(""),
                    titleAlt: n("")
                }
            }

            function n(t) {
                var e = t,
                    n = function a() {
                        return 1 !== arguments.length || r(arguments[0]) ? e : void a.assign(null, arguments[0])
                    };
                return n.assign = function (t, n) {
                    e = n
                }, n
            }

            function r(t) {
                return null != t && a.isFunction(t.$new)
            }
            return {
                buildColumn: t
            }
        }
        var a = n(0);
        r.$inject = [], e.ngTableColumn = r
    }, function (t, e) {
        "use strict";

        function n(t) {
            function e(e, n, r) {
                var a = t(r.ngTableColumnsBinding).assign;
                a && e.$watch("$columns", function (t) {
                    var n = (t || []).slice(0);
                    a(e, n)
                })
            }
            var n = {
                restrict: "A",
                require: "ngTable",
                link: e
            };
            return n
        }
        n.$inject = ["$parse"], e.ngTableColumnsBinding = n
    }, function (t, e, n) {
        "use strict";

        function r(t, e, n, r, i, o, l, s, u, c) {
            function p(e) {
                if (e && !t.params.hasErrorState()) {
                    var n = t.params,
                        r = n.settings().filterOptions;
                    if (n.hasFilterChanges()) {
                        var a = function () {
                            n.page(1), n.reload()
                        };
                        r.filterDelay ? v(a, r.filterDelay) : a()
                    } else n.reload()
                }
            }

            function f() {
                o.showFilter ? t.$parent.$watch(o.showFilter, function (e) {
                    t.show_filter = e
                }) : t.$watch(h, function (e) {
                    t.show_filter = e
                }), o.disableFilter && t.$parent.$watch(o.disableFilter, function (e) {
                    t.$filterRow.disabled = e
                })
            }

            function g() {
                if (t.$groupRow = {
                    show: !1
                }, o.showGroup) {
                    var e = r(o.showGroup);
                    t.$parent.$watch(e, function (e) {
                        t.$groupRow.show = e
                    }), e.assign && t.$watch("$groupRow.show", function (n) {
                        e.assign(t.$parent, n)
                    })
                } else t.$watch("params.hasGroup()", function (e) {
                    t.$groupRow.show = e
                })
            }

            function d() {
                return (t.$columns || []).filter(function (e) {
                    return e.show(t)
                })
            }

            function h() {
                return !!t.$columns && m(t.$columns, function (e) {
                    return e.show(t) && !!e.filter(t)
                })
            }

            function m(t, e) {
                for (var n = !1, r = 0; r < t.length; r++) {
                    var a = t[r];
                    if (e(a)) {
                        n = !0;
                        break
                    }
                }
                return n
            }

            function b() {
                c.onAfterReloadData(function (e, n) {
                    var r = d();
                    e.hasGroup() ? (t.$groups = n || [], t.$groups.visibleColumnCount = r.length) : (t.$data = n || [], t.$data.visibleColumnCount = r.length)
                }, t, function (e) {
                    return t.params === e
                }), c.onPagesChanged(function (e, n) {
                    t.pages = n
                }, t, function (e) {
                    return t.params === e
                })
            }
            t.$filterRow = {
                disabled: !1
            }, t.$loading = !1, t.hasOwnProperty("params") || (t.params = new e((!0)));
            var v = function () {
                var t;
                return function (e, r) {
                    n.cancel(t), t = n(e, r)
                }
            }();
            t.$watch("params", function (t, e) {
                t !== e && t && t.reload()
            }, !1), t.$watch("params.isDataReloadRequired()", p), this.compileDirectiveTemplates = function () {
                if (!l.hasClass("ng-table")) {
                    t.templates = {
                        header: o.templateHeader ? o.templateHeader : "ng-table/header.html",
                        pagination: o.templatePagination ? o.templatePagination : "ng-table/pager.html"
                    }, l.addClass("ng-table");
                    var e = null,
                        n = !1;
                    a.forEach(l.children(), function (t) {
                        "THEAD" === t.tagName && (n = !0)
                    }), n || (e = a.element('<thead ng-include="templates.header"></thead>', s), l.prepend(e));
                    var r = a.element('<div ng-table-pagination="params" template-url="templates.pagination"></div>', s);
                    l.after(r), e && i(e)(t), i(r)(t)
                }
            }, this.loadFilterData = function (e) {
                function n(t) {
                    return t && "object" == typeof t && "function" == typeof t.then
                }
                a.forEach(e, function (e) {
                    var r = e.filterData(t);
                    return r ? n(r) ? (delete e.filterData, r.then(function (t) {
                        a.isArray(t) || a.isFunction(t) || a.isObject(t) || (t = []), e.data = t
                    })) : e.data = r : void delete e.filterData
                })
            }, this.buildColumns = function (e) {
                var n = [];
                return (e || []).forEach(function (e) {
                    n.push(u.buildColumn(e, t, n))
                }), n
            }, this.parseNgTableDynamicExpr = function (t) {
                if (!t || t.indexOf(" with ") > -1) {
                    var e = t.split(/\s+with\s+/);
                    return {
                        tableParams: e[0],
                        columns: e[1]
                    }
                }
                throw new Error("Parse error (expected example: ng-table-dynamic='tableParams with cols')")
            }, this.setupBindingsToInternalScope = function (e) {
                t.$watch(e, function (e) {
                    void 0 !== e && (t.params = e)
                }, !1), f(), g()
            }, b()
        }
        var a = n(0);
        r.$inject = ["$scope", "NgTableParams", "$timeout", "$parse", "$compile", "$attrs", "$element", "$document", "ngTableColumn", "ngTableEventsChannel"], e.ngTableController = r
    }, function (t, e, n) {
        "use strict";

        function r() {
            return {
                restrict: "A",
                priority: 1001,
                scope: !0,
                controller: "ngTableController",
                compile: function (t) {
                    var e;
                    if (a.forEach(t.find("tr"), function (t) {
                            t = a.element(t), t.hasClass("ng-table-group") || e || (e = t)
                    }), e) return a.forEach(e.find("td"), function (t) {
                        var e = a.element(t),
                            n = function (t) {
                                return e.attr("x-data-" + t) || e.attr("data-" + t) || e.attr(t)
                            },
                            r = n("title");
                        r || e.attr("data-title-text", "{{$columns[$index].titleAlt(this) || $columns[$index].title(this)}}");
                        var i = e.attr("ng-if");
                        i || e.attr("ng-if", "$columns[$index].show(this)")
                    }),
                    function (t, e, n, r) {
                        var a = r.parseNgTableDynamicExpr(n.ngTableDynamic);
                        r.setupBindingsToInternalScope(a.tableParams), r.compileDirectiveTemplates(), t.$watchCollection(a.columns, function (e) {
                            t.$columns = r.buildColumns(e), r.loadFilterData(t.$columns)
                        })
                    }
                }
            }
        }
        var a = n(0);
        r.$inject = [], e.ngTableDynamic = r
    }, function (t, e, n) {
        "use strict";

        function r() {
            function t() {
                e()
            }

            function e() {
                i = o
            }

            function n(t) {
                var e = a.extend({}, i, t);
                e.aliasUrls = a.extend({}, i.aliasUrls, t.aliasUrls), i = e
            }

            function r() {
                function t(t, e) {
                    var n;
                    return n = "string" != typeof t ? t.id : t, n.indexOf("/") !== -1 ? n : r.getUrlForAlias(n, e)
                }

                function e(t, e) {
                    return i.aliasUrls[t] || i.defaultBaseUrl + t + i.defaultExt
                }
                var n, r = {
                    config: n,
                    getTemplateUrl: t,
                    getUrlForAlias: e
                };
                return Object.defineProperty(r, "config", {
                    get: function () {
                        return n = n || a.copy(i)
                    },
                    enumerable: !0
                }), r
            }
            var i, o = {
                defaultBaseUrl: "ng-table/filters/",
                defaultExt: ".html",
                aliasUrls: {}
            };
            this.$get = r, this.resetConfigs = e, this.setConfig = n, t(), r.$inject = []
        }
        var a = n(0);
        r.$inject = [], e.ngTableFilterConfigProvider = r
    }, function (t, e, n) {
        "use strict";

        function r() {
            var t = {
                restrict: "E",
                replace: !0,
                templateUrl: a,
                scope: !0,
                controller: "ngTableFilterRowController"
            };
            return t
        }
        var a = n(24);
        r.$inject = [], e.ngTableFilterRow = r
    }, function (t, e) {
        "use strict";

        function n(t, e) {
            t.config = e, t.getFilterCellCss = function (t, e) {
                if ("horizontal" !== e) return "s12";
                var n = Object.keys(t).length,
                    r = parseInt((12 / n).toString(), 10);
                return "s" + r
            }, t.getFilterPlaceholderValue = function (t, e) {
                return "string" == typeof t ? "" : t.placeholder
            }
        }
        n.$inject = ["$scope", "ngTableFilterConfig"], e.ngTableFilterRowController = n
    }, function (t, e, n) {
        "use strict";

        function r() {
            var t = {
                restrict: "E",
                replace: !0,
                templateUrl: a,
                scope: !0,
                controller: "ngTableGroupRowController",
                controllerAs: "dctrl"
            };
            return t
        }
        var a = n(29);
        r.$inject = [], e.ngTableGroupRow = r
    }, function (t, e) {
        "use strict";

        function n(t) {
            function e() {
                t.getGroupables = i, t.getGroupTitle = a, t.getVisibleColumns = o, t.groupBy = l, t.isSelectedGroup = u, t.toggleDetail = p, t.$watch("params.group()", c, !0)
            }

            function n() {
                var e;
                e = t.params.hasGroup(t.$selGroup, "asc") ? "desc" : t.params.hasGroup(t.$selGroup, "desc") ? "" : "asc", t.params.group(t.$selGroup, e)
            }

            function r(e) {
                return t.$columns.filter(function (n) {
                    return n.groupable(t) === e
                })[0]
            }

            function a(e) {
                return s(e) ? e.title : e.title(t)
            }

            function i() {
                var e = t.$columns.filter(function (e) {
                    return !!e.groupable(t)
                });
                return f.concat(e)
            }

            function o() {
                return t.$columns.filter(function (e) {
                    return e.show(t)
                })
            }

            function l(e) {
                u(e) ? n() : s(e) ? t.params.group(e) : t.params.group(e.groupable(t))
            }

            function s(t) {
                return "function" == typeof t
            }

            function u(e) {
                return s(e) ? e === t.$selGroup : e.groupable(t) === t.$selGroup
            }

            function c(e) {
                var n = r(t.$selGroup);
                if (n && n.show.assign && n.show.assign(t, !0), s(e)) f = [e], t.$selGroup = e, t.$selGroupTitle = e.title;
                else {
                    var a = Object.keys(e || {})[0],
                        i = r(a);
                    i && (t.$selGroupTitle = i.title(t), t.$selGroup = a, i.show.assign && i.show.assign(t, !1))
                }
            }

            function p() {
                return t.params.settings().groupOptions.isExpanded = !t.params.settings().groupOptions.isExpanded, t.params.reload()
            }
            var f = [];
            e()
        }
        n.$inject = ["$scope"], e.ngTableGroupRowController = n
    }, function (t, e, n) {
        "use strict";

        function r(t, e, n) {
            return {
                restrict: "A",
                scope: {
                    params: "=ngTablePagination",
                    templateUrl: "="
                },
                replace: !1,
                link: function (r, i) {
                    n.onAfterReloadData(function (t) {
                        r.pages = t.generatePagesArray()
                    }, r, function (t) {
                        return t === r.params
                    }), r.$watch("templateUrl", function (n) {
                        if (void 0 !== n) {
                            var o = a.element('<div ng-include="templateUrl"></div>', e);
                            i.append(o), t(o)(r)
                        }
                    })
                }
            }
        }
        var a = n(0);
        r.$inject = ["$compile", "$document", "ngTableEventsChannel"], e.ngTablePagination = r
    }, function (t, e) {
        "use strict";

        function n() {
            var t = {
                restrict: "A",
                controller: r
            };
            return t
        }

        function r(t, e, n, r) {
            function a() {
                s = e(n.ngTableSelectFilterDs)(t), t.$watch(function () {
                    return s && s.data
                }, i)
            }

            function i() {
                l(s).then(function (e) {
                    e && !o(e) && e.unshift({
                        id: "",
                        title: ""
                    }), e = e || [], t.$selectData = e
                })
            }

            function o(t) {
                for (var e, n = 0; n < t.length; n++) {
                    var r = t[n];
                    if (r && "" === r.id) {
                        e = !0;
                        break
                    }
                }
                return e
            }

            function l(t) {
                var e = t.data;
                return e instanceof Array ? r.when(e) : r.when(e && e())
            }
            var s;
            a()
        }
        n.$inject = [], e.ngTableSelectFilterDs = n, r.$inject = ["$scope", "$parse", "$attrs", "$q"]
    }, function (t, e, n) {
        "use strict";

        function r() {
            var t = {
                restrict: "E",
                replace: !0,
                templateUrl: a,
                scope: !0,
                controller: "ngTableSorterRowController"
            };
            return t
        }
        var a = n(32);
        r.$inject = [], e.ngTableSorterRow = r
    }, function (t, e) {
        "use strict";

        function n(t) {
            function e(e, n) {
                var r = e.sortable && e.sortable();
                if (r && "string" == typeof r) {
                    var a = t.params.settings().defaultSort,
                        i = "asc" === a ? "desc" : "asc",
                        o = t.params.sorting() && t.params.sorting()[r] && t.params.sorting()[r] === a,
                        l = n.ctrlKey || n.metaKey ? t.params.sorting() : {};
                    l[r] = o ? i : a, t.params.parameters({
                        sorting: l
                    })
                }
            }
            t.sortBy = e
        }
        n.$inject = ["$scope"], e.ngTableSorterRowController = n
    }, function (t, e) {
        "use strict"
    }, function (t, e, n) {
        "use strict";
        var r = n(0),
            a = function () {
                function t() {
                    function t(t) {
                        function n(n) {
                            var a = n.settings().filterOptions;
                            return r.isFunction(a.filterFn) ? a.filterFn : t(a.filterFilterName || e.filterFilterName)
                        }

                        function a(n) {
                            return t(e.sortingFilterName)
                        }

                        function i(t, e) {
                            if (!e.hasFilter()) return t;
                            var r = e.filter(!0),
                                a = Object.keys(r),
                                i = a.reduce(function (t, e) {
                                    return t = u(t, r[e], e)
                                }, {}),
                                o = n(e);
                            return o.call(e, t, i, e.settings().filterOptions.filterComparator)
                        }

                        function o(t, e) {
                            var n = t.slice((e.page() - 1) * e.count(), e.page() * e.count());
                            return e.total(t.length), n
                        }

                        function l(t, e) {
                            var n = e.orderBy(),
                                r = a(e);
                            return n.length ? r(t, n) : t
                        }

                        function s(t, e) {
                            if (null == t) return [];
                            var n = r.extend({}, c, e.settings().dataOptions),
                                a = n.applyFilter ? i(t, e) : t,
                                s = n.applySort ? l(a, e) : a;
                            return n.applyPaging ? o(s, e) : s
                        }

                        function u(t, e, n) {
                            var r = n.split("."),
                                a = t,
                                i = r[r.length - 1],
                                o = a,
                                l = r.slice(0, r.length - 1);
                            return l.forEach(function (t) {
                                o.hasOwnProperty(t) || (o[t] = {}), o = o[t]
                            }), o[i] = e, a
                        }
                        var c = {
                            applyFilter: !0,
                            applySort: !0,
                            applyPaging: !0
                        };
                        return s.applyPaging = o, s.getFilterFn = n, s.getOrderByFn = a, s
                    }
                    this.filterFilterName = "filter", this.sortingFilterName = "orderBy";
                    var e = this;
                    this.$get = t, t.$inject = ["$filter"]
                }
                return t
            }();
        e.ngTableDefaultGetDataProvider = a
    }, function (t, e) {
        "use strict";
        e.ngTableDefaults = {
            params: {},
            settings: {}
        }
    }, function (t, e, n) {
        "use strict";

        function r(t) {
            function e(t, e) {
                var i = t.charAt(0).toUpperCase() + t.substring(1),
                    o = (l = {}, l["on" + i] = n(t), l["publish" + i] = r(t), l);
                return a.extend(e, o);
                var l
            }

            function n(e) {
                function n(t) {
                    return t ? r(t) ? t : function (e) {
                        return e === t
                    } : function (t) {
                        return !0
                    }
                }

                function r(t) {
                    return "function" == typeof t
                }

                function a(t) {
                    return t && "function" == typeof t.$new
                }
                return function (r, i, o) {
                    var l, s = t;
                    return a(i) ? (s = i, l = n(o)) : l = n(i), s.$on("ngTable:" + e, function (t, e) {
                        for (var n = [], a = 2; a < arguments.length; a++) n[a - 2] = arguments[a];
                        if (!e.isNullInstance) {
                            var i = [e].concat(n);
                            l.apply(this, i) && r.apply(this, i)
                        }
                    })
                }
            }

            function r(e) {
                return function () {
                    for (var n = [], r = 0; r < arguments.length; r++) n[r - 0] = arguments[r];
                    t.$broadcast.apply(t, ["ngTable:" + e].concat(n))
                }
            }
            var i = {};
            return i = e("afterCreated", i), i = e("afterReloadData", i), i = e("datasetChanged", i), i = e("pagesChanged", i)
        }
        var a = n(0);
        r.$inject = ["$rootScope"], e.ngTableEventsChannel = r
    }, function (t, e, n) {
        "use strict";

        function r(t, e, n, r, i, o) {
            function l(n, l) {
                function s(t) {
                    return !isNaN(parseFloat(t)) && isFinite(t)
                }

                function u(t) {
                    var e = F.groupOptions && F.groupOptions.defaultSort;
                    if (t) {
                        if (f(t)) return null == t.sortDirection && (t.sortDirection = e), t;
                        if ("object" == typeof t) {
                            for (var n in t) null == t[n] && (t[n] = e);
                            return t
                        }
                        return r = {}, r[t] = e, r
                    }
                    return t;
                    var r
                }

                function c(t) {
                    var e = [];
                    for (var n in t) e.push(("asc" === t[n] ? "+" : "-") + n);
                    return e
                }

                function p() {
                    var t = O.group;
                    return {
                        params: O,
                        groupSortDirection: f(t) ? t.sortDirection : void 0
                    }
                }

                function f(t) {
                    return "function" == typeof t
                }

                function g() {
                    var t = O.filter && O.filter.$,
                        e = b && b.params.filter && b.params.filter.$;
                    return !a.equals(t, e)
                }

                function d() {
                    F.filterOptions.filterDelay === C.filterDelay && F.total <= F.filterOptions.filterDelayThreshold && F.getData === x.getData && (F.filterOptions.filterDelay = 0)
                }

                function h(e) {
                    var n = F.interceptors || [];
                    return n.reduce(function (e, n) {
                        var r = n.response && n.response.bind(n) || t.when,
                            a = n.responseError && n.responseError.bind(n) || t.reject;
                        return e.then(function (t) {
                            return r(t, $)
                        }, function (t) {
                            return a(t, $)
                        })
                    }, e)
                }

                function m() {
                    function e(t) {
                        return i(t.settings().dataset, t)
                    }

                    function n(e) {
                        var n, o = e.group(),
                            l = void 0;
                        if (f(o)) n = o, l = o.sortDirection;
                        else {
                            var s = Object.keys(o)[0];
                            l = o[s], n = function (t) {
                                return r(t, s)
                            }
                        }
                        var u = e.settings(),
                            p = u.dataOptions;
                        u.dataOptions = {
                            applyPaging: !1
                        };
                        var g = u.getData,
                            d = t.when(g(e));
                        return d.then(function (t) {
                            var r = {};
                            a.forEach(t, function (t) {
                                var e = n(t);
                                r[e] = r[e] || {
                                    data: [],
                                    $hideRows: !u.groupOptions.isExpanded,
                                    value: e
                                }, r[e].data.push(t)
                            });
                            var o = [];
                            for (var s in r) o.push(r[s]);
                            if (l) {
                                var p = i.getOrderByFn(),
                                    f = c({
                                        value: l
                                    });
                                o = p(o, f)
                            }
                            return i.applyPaging(o, e)
                        }).finally(function () {
                            u.dataOptions = p
                        })
                    }

                    function r(t, e) {
                        var n;
                        if (n = "string" == typeof e ? e.split(".") : e, void 0 !== t) {
                            if (0 === n.length) return t;
                            if (null !== t) return r(t[n[0]], n.slice(1))
                        }
                    }
                    return {
                        getData: e,
                        getGroups: n
                    }
                }
                "boolean" == typeof n && (this.isNullInstance = !0);
                var b, v, $ = this,
                    y = !1,
                    w = [],
                    T = function () {
                        for (var t = [], n = 0; n < arguments.length; n++) t[n - 0] = arguments[n];
                        F.debugMode && e.debug && e.debug.apply(e, t)
                    },
                    C = {
                        filterComparator: void 0,
                        filterDelay: 500,
                        filterDelayThreshold: 1e4,
                        filterFilterName: void 0,
                        filterFn: void 0,
                        filterLayout: "stack"
                    },
                    D = {
                        defaultSort: "asc",
                        isExpanded: !0
                    },
                    x = m();
                this.data = [], this.parameters = function (t, e) {
                    if (e = e || !1, void 0 !== typeof t) {
                        for (var n in t) {
                            var r = t[n];
                            if (e && n.indexOf("[") >= 0) {
                                for (var i = n.split(/\[(.*)\]/).reverse(), o = "", l = 0, c = i.length; l < c; l++) {
                                    var p = i[l];
                                    if ("" !== p) {
                                        var f = r;
                                        r = {}, r[o = p] = s(f) ? parseFloat(f) : f
                                    }
                                }
                                "sorting" === o && (O[o] = {}), O[o] = a.extend(O[o] || {}, r[o])
                            } else "group" === n ? O[n] = u(t[n]) : O[n] = s(t[n]) ? parseFloat(t[n]) : t[n]
                        }
                        return T("ngTable: set parameters", O), this
                    }
                    return O
                }, this.settings = function (t) {
                    if (a.isDefined(t)) {
                        t.filterOptions && (t.filterOptions = a.extend({}, F.filterOptions, t.filterOptions)), t.groupOptions && (t.groupOptions = a.extend({}, F.groupOptions, t.groupOptions)), a.isArray(t.dataset) && (t.total = t.dataset.length);
                        var e = F.dataset;
                        F = a.extend(F, t), a.isArray(t.dataset) && d();
                        var n = t.hasOwnProperty("dataset") && t.dataset != e;
                        if (n) {
                            y && this.page(1), y = !1;
                            var r = function () {
                                o.publishDatasetChanged($, t.dataset, e)
                            };
                            w ? w.push(r) : r()
                        }
                        return T("ngTable: set settings", F), this
                    }
                    return F
                }, this.page = function (t) {
                    return void 0 !== t ? this.parameters({
                        page: t
                    }) : O.page
                }, this.total = function (t) {
                    return void 0 !== t ? this.settings({
                        total: t
                    }) : F.total
                }, this.count = function (t) {
                    return void 0 !== t ? this.parameters({
                        count: t,
                        page: 1
                    }) : O.count
                }, this.filter = function (t) {
                    if (null != t && "object" == typeof t) return this.parameters({
                        filter: t,
                        page: 1
                    });
                    if (t === !0) {
                        for (var e = Object.keys(O.filter), n = {}, r = 0; r < e.length; r++) {
                            var a = O.filter[e[r]];
                            null != a && "" !== a && (n[e[r]] = a)
                        }
                        return n
                    }
                    return O.filter
                }, this.group = function (t, e) {
                    if (void 0 === t) return O.group;
                    var n = {
                        page: 1
                    };
                    return f(t) && void 0 !== e ? (t.sortDirection = e, n.group = t) : "string" == typeof t && void 0 !== e ? n.group = (r = {}, r[t] = e, r) : n.group = t, this.parameters(n), this;
                    var r
                }, this.sorting = function (t, e) {
                    return "string" == typeof t && void 0 !== e ? (this.parameters({
                        sorting: (n = {}, n[t] = e, n)
                    }), this) : void 0 !== t ? this.parameters({
                        sorting: t
                    }) : O.sorting;
                    var n
                }, this.isSortBy = function (t, e) {
                    return void 0 !== e ? void 0 !== O.sorting[t] && O.sorting[t] == e : void 0 !== O.sorting[t]
                }, this.orderBy = function () {
                    return c(O.sorting)
                }, this.generatePagesArray = function (t, e, n, r) {
                    arguments.length || (t = this.page(), e = this.total(), n = this.count());
                    var a, i, o, l;
                    r = r && r < 6 ? 6 : r;
                    var s = [];
                    if (l = Math.ceil(e / n), l > 1) {
                        s.push({
                            type: "prev",
                            number: Math.max(1, t - 1),
                            active: t > 1
                        }), s.push({
                            type: "first",
                            number: 1,
                            active: t > 1,
                            current: 1 === t
                        }), i = Math.round((F.paginationMaxBlocks - F.paginationMinBlocks) / 2), o = Math.max(2, t - i), a = Math.min(l - 1, t + 2 * i - (t - o)), o = Math.max(2, o - (2 * i - (a - o)));
                        for (var u = o; u <= a;) u === o && 2 !== u || u === a && u !== l - 1 ? s.push({
                            type: "more",
                            active: !1
                        }) : s.push({
                            type: "page",
                            number: u,
                            active: t !== u,
                            current: t === u
                        }), u++;
                        s.push({
                            type: "last",
                            number: l,
                            active: t !== l,
                            current: t === l
                        }), s.push({
                            type: "next",
                            number: Math.min(l, t + 1),
                            active: t < l
                        })
                    }
                    return s
                }, this.isDataReloadRequired = function () {
                    return !y || !a.equals(p(), b) || g()
                }, this.hasFilter = function () {
                    return Object.keys(this.filter(!0)).length > 0
                }, this.hasGroup = function (t, e) {
                    return null == t ? f(O.group) || Object.keys(O.group).length > 0 : f(t) ? null == e ? O.group === t : O.group === t && t.sortDirection === e : null == e ? Object.keys(O.group).indexOf(t) !== -1 : O.group[t] === e
                }, this.hasFilterChanges = function () {
                    var t = b && b.params.filter;
                    return !a.equals(O.filter, t) || g()
                }, this.url = function (t) {
                    function e(t, e) {
                        n(i) ? i.push(e + "=" + encodeURIComponent(t)) : i[e] = encodeURIComponent(t)
                    }

                    function n(e) {
                        return t
                    }

                    function r(t, e) {
                        return "group" === e || void 0 !== typeof t && "" !== t
                    }
                    t = t || !1;
                    var i = t ? [] : {};
                    for (var o in O)
                        if (O.hasOwnProperty(o)) {
                            var l = O[o],
                                s = encodeURIComponent(o);
                            if ("object" == typeof l) {
                                for (var u in l)
                                    if (r(l[u], o)) {
                                        var c = s + "[" + encodeURIComponent(u) + "]";
                                        e(l[u], c)
                                    }
                            } else !a.isFunction(l) && r(l, o) && e(l, s)
                        }
                    return i
                }, this.reload = function () {
                    var e = this,
                        n = null;
                    if (F.$loading = !0, b = a.copy(p()), y = !0, e.hasGroup()) n = h(t.when(F.getGroups(e)));
                    else {
                        var r = F.getData;
                        n = h(t.when(r(e)))
                    }
                    T("ngTable: reload data");
                    var i = e.data;
                    return n.then(function (t) {
                        return F.$loading = !1, v = null, e.data = t, o.publishAfterReloadData(e, t, i), e.reloadPages(), t
                    }).catch(function (e) {
                        return v = b, t.reject(e)
                    })
                }, this.hasErrorState = function () {
                    return !(!v || !a.equals(v, p()))
                }, this.reloadPages = function () {
                    var t;
                    return function () {
                        var e = t,
                            n = $.generatePagesArray($.page(), $.total(), $.count());
                        a.equals(e, n) || (t = n, o.publishPagesChanged(this, n, e))
                    }
                }();
                var O = {
                    page: 1,
                    count: 10,
                    filter: {},
                    sorting: {},
                    group: {}
                };
                a.extend(O, r.params);
                var F = {
                    $loading: !1,
                    dataset: null,
                    total: 0,
                    defaultSort: "desc",
                    filterOptions: a.copy(C),
                    groupOptions: a.copy(D),
                    counts: [10, 25, 50, 100],
                    interceptors: [],
                    paginationMaxBlocks: 11,
                    paginationMinBlocks: 5,
                    sortingIndicator: "span"
                };
                return this.settings(x), this.settings(r.settings), this.settings(l), this.parameters(n, !0), o.publishAfterCreated(this), a.forEach(w, function (t) {
                    t()
                }), w = null, this
            }
            return l
        }
        var a = n(0);
        r.$inject = ["$q", "$log", "$filter", "ngTableDefaults", "ngTableDefaultGetData", "ngTableEventsChannel"], e.ngTableParamsFactory = r
    }, 18, function (t, e, n) {
        var r = "ng-table/filterRow.html",
            a = '<tr ng-show=show_filter class=ng-table-filters> <th data-title-text="{{$column.titleAlt(this) || $column.title(this)}}" ng-repeat="$column in $columns" ng-if=$column.show(this) class="filter {{$column.class(this)}}" ng-class="params.settings().filterOptions.filterLayout === \'horizontal\' ? \'filter-horizontal\' : \'\'"> <div ng-repeat="(name, filter) in $column.filter(this)" ng-include=config.getTemplateUrl(filter) class=filter-cell ng-class="[getFilterCellCss($column.filter(this), params.settings().filterOptions.filterLayout), $last ? \'last\' : \'\']"> </div> </th> </tr> ',
            i = n(0);
        i.module("ng").run(["$templateCache", function (t) {
            t.put(r, a)
        }]), t.exports = r
    }, function (t, e, n) {
        var r = "ng-table/filters/number.html",
            a = '<input type=number name={{name}} ng-disabled=$filterRow.disabled ng-model=params.filter()[name] class="input-filter form-control" placeholder="{{getFilterPlaceholderValue(filter, name)}}"/> ',
            i = n(0);
        i.module("ng").run(["$templateCache", function (t) {
            t.put(r, a)
        }]), t.exports = r
    }, function (t, e, n) {
        var r = "ng-table/filters/select-multiple.html",
            a = '<select ng-options="data.id as data.title for data in $column.data" ng-disabled=$filterRow.disabled multiple=multiple ng-multiple=true ng-model=params.filter()[name] class="filter filter-select-multiple form-control" name={{name}}> </select> ',
            i = n(0);
        i.module("ng").run(["$templateCache", function (t) {
            t.put(r, a)
        }]), t.exports = r
    }, function (t, e, n) {
        var r = "ng-table/filters/select.html",
            a = '<select ng-options="data.id as data.title for data in $selectData" ng-table-select-filter-ds=$column ng-disabled=$filterRow.disabled ng-model=params.filter()[name] class="filter filter-select form-control" name={{name}}> <option style=display:none value=""></option> </select> ',
            i = n(0);
        i.module("ng").run(["$templateCache", function (t) {
            t.put(r, a)
        }]), t.exports = r
    }, function (t, e, n) {
        var r = "ng-table/filters/text.html",
            a = '<input type=text name={{name}} ng-disabled=$filterRow.disabled ng-model=params.filter()[name] class="input-filter form-control" placeholder="{{getFilterPlaceholderValue(filter, name)}}"/> ',
            i = n(0);
        i.module("ng").run(["$templateCache", function (t) {
            t.put(r, a)
        }]), t.exports = r
    }, function (t, e, n) {
        var r = "ng-table/groupRow.html",
            a = '<tr ng-if=params.hasGroup() ng-show=$groupRow.show class=ng-table-group-header> <th colspan={{getVisibleColumns().length}} class=sortable ng-class="{\n                    \'sort-asc\': params.hasGroup($selGroup, \'asc\'),\n                    \'sort-desc\':params.hasGroup($selGroup, \'desc\')\n                  }"> <a href="" ng-click="isSelectorOpen = !isSelectorOpen" class=ng-table-group-selector> <strong class=sort-indicator>{{$selGroupTitle}}</strong> <button class="btn btn-default btn-xs ng-table-group-close" ng-click="$groupRow.show = false; $event.preventDefault(); $event.stopPropagation();"> <span class="glyphicon glyphicon-remove"></span> </button> <button class="btn btn-default btn-xs ng-table-group-toggle" ng-click="toggleDetail(); $event.preventDefault(); $event.stopPropagation();"> <span class=glyphicon ng-class="{\n                    \'glyphicon-resize-small\': params.settings().groupOptions.isExpanded,\n                    \'glyphicon-resize-full\': !params.settings().groupOptions.isExpanded\n                }"></span> </button> </a> <div class=list-group ng-if=isSelectorOpen> <a href="" class=list-group-item ng-repeat="group in getGroupables()" ng-click=groupBy(group)> <strong>{{ getGroupTitle(group)}}</strong> <strong ng-class="isSelectedGroup(group) && \'sort-indicator\'"></strong> </a> </div> </th> </tr> ',
            i = n(0);
        i.module("ng").run(["$templateCache", function (t) {
            t.put(r, a)
        }]), t.exports = r
    }, function (t, e, n) {
        var r = "ng-table/header.html",
            a = "<ng-table-group-row></ng-table-group-row> <ng-table-sorter-row></ng-table-sorter-row> <ng-table-filter-row></ng-table-filter-row> ",
            i = n(0);
        i.module("ng").run(["$templateCache", function (t) {
            t.put(r, a)
        }]), t.exports = r
    }, function (t, e, n) {
        var r = "ng-table/pager.html",
            a = '<div class="ng-cloak ng-table-pager" ng-if=params.data.length> <div ng-if=params.settings().counts.length class="ng-table-counts btn-group pull-right"> <button ng-repeat="count in params.settings().counts" type=button ng-class="{\'active\':params.count() == count}" ng-click=params.count(count) class="btn btn-default"> <span ng-bind=count></span> </button> </div> <ul ng-if=pages.length class="pagination ng-table-pagination"> <li ng-class="{\'disabled\': !page.active && !page.current, \'active\': page.current}" ng-repeat="page in pages" ng-switch=page.type> <a ng-switch-when=prev ng-click=params.page(page.number) href="">&laquo;</a> <a ng-switch-when=first ng-click=params.page(page.number) href=""><span ng-bind=page.number></span></a> <a ng-switch-when=page ng-click=params.page(page.number) href=""><span ng-bind=page.number></span></a> <a ng-switch-when=more ng-click=params.page(page.number) href="">&#8230;</a> <a ng-switch-when=last ng-click=params.page(page.number) href=""><span ng-bind=page.number></span></a> <a ng-switch-when=next ng-click=params.page(page.number) href="">&raquo;</a> </li> </ul> </div> ',
            i = n(0);
        i.module("ng").run(["$templateCache", function (t) {
            t.put(r, a)
        }]), t.exports = r
    }, function (t, e, n) {
        var r = "ng-table/sorterRow.html",
            a = "<tr class=ng-table-sort-header> <th title={{$column.headerTitle(this)}} ng-repeat=\"$column in $columns\" ng-class=\"{\n                    'sortable': $column.sortable(this),\n                    'sort-asc': params.sorting()[$column.sortable(this)]=='asc',\n                    'sort-desc': params.sorting()[$column.sortable(this)]=='desc'\n                  }\" ng-click=\"sortBy($column, $event)\" ng-if=$column.show(this) ng-init=\"template = $column.headerTemplateURL(this)\" class=\"header {{$column.class(this)}}\"> <div ng-if=!template class=ng-table-header ng-class=\"{'sort-indicator': params.settings().sortingIndicator == 'div'}\"> <span ng-bind=$column.title(this) ng-class=\"{'sort-indicator': params.settings().sortingIndicator == 'span'}\"></span> </div> <div ng-if=template ng-include=template></div> </th> </tr> ",
            i = n(0);
        i.module("ng").run(["$templateCache", function (t) {
            t.put(r, a)
        }]), t.exports = r
    }, function (t, e, n) {
        "use strict";

        function r(t) {
            for (var n in t) e.hasOwnProperty(n) || (e[n] = t[n])
        }
        var a = n(0),
            i = n(2),
            o = n(1),
            l = a.module("ngTable", [i.default.name, o.default.name]);
        e.ngTable = l, r(n(2)), r(n(1))
    }]))
});
//# sourceMappingURL=ng-table.min.js.map