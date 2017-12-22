﻿! function (t) {
    function o(t) {
        return "undefined" == typeof t.which ? !0 : "number" == typeof t.which && t.which > 0 ? !t.ctrlKey && !t.metaKey && !t.altKey && 8 != t.which && 9 != t.which && 13 != t.which && 16 != t.which && 17 != t.which && 20 != t.which && 27 != t.which : !1
    }

    function i(o) {
        var i = t(o);
        i.prop("disabled") || i.closest(".form-group").addClass("is-focused")
    }

    function n(o) {
        o.closest("label").hover(function () {
            var o = t(this).find("input");
            o.prop("disabled") || i(o)
        }, function () {
            e(t(this).find("input"))
        })
    }

    function e(o) {
        t(o).closest(".form-group").removeClass("is-focused")
    }
    t.expr[":"].notmdproc = function (o) {
        return t(o).data("mdproc") ? !1 : !0
    }, t.material = {
        options: {
            validate: !0,
            input: !0,
            ripples: !0,
            checkbox: !0,
            togglebutton: !0,
            radio: !0,
            arrive: !0,
            autofill: !1,
            withRipples: [".btn:not(.btn-link)", ".card-image", ".navbar a:not(.withoutripple)", ".footer a:not(.withoutripple)", ".dropdown-menu a", ".nav-tabs a:not(.withoutripple)", ".withripple", ".pagination li:not(.active):not(.disabled) a:not(.withoutripple)"].join(","),
            inputElements: "input.form-control, textarea.form-control, select.form-control",
            checkboxElements: ".checkbox > label > input[type=checkbox]",
            togglebuttonElements: ".togglebutton > label > input[type=checkbox]",
            radioElements: ".radio > label > input[type=radio]"
        },
        checkbox: function (o) {
            var i = t(o ? o : this.options.checkboxElements).filter(":notmdproc").data("mdproc", !0).after("<span class='checkbox-material'><span class='check'></span></span>");
            n(i)
        },
        togglebutton: function (o) {
            var i = t(o ? o : this.options.togglebuttonElements).filter(":notmdproc").data("mdproc", !0).after("<span class='toggle'></span>");
            n(i)
        },
        radio: function (o) {
            var i = t(o ? o : this.options.radioElements).filter(":notmdproc").data("mdproc", !0).after("<span class='circle'></span><span class='check'></span>");
            n(i)
        },
        input: function (o) {
            t(o ? o : this.options.inputElements).filter(":notmdproc").data("mdproc", !0).each(function () {
                var o = t(this),
                    i = o.closest(".form-group");
                0 === i.length && (o.wrap("<div class='form-group'></div>"), i = o.closest(".form-group")), o.attr("data-hint") && (o.after("<p class='help-block'>" + o.attr("data-hint") + "</p>"), o.removeAttr("data-hint"));
                var n = {
                    "input-lg": "form-group-lg",
                    "input-sm": "form-group-sm"
                };
                if (t.each(n, function (t, n) {
                    o.hasClass(t) && (o.removeClass(t), i.addClass(n))
                }), o.hasClass("floating-label")) {
                    var e = o.attr("placeholder");
                    o.attr("placeholder", null).removeClass("floating-label");
                    var a = o.attr("id"),
                        r = "";
                    a && (r = "for='" + a + "'"), i.addClass("label-floating"), o.after("<label " + r + "class='control-label'>" + e + "</label>")
                } (null === o.val() || "undefined" == o.val() || "" === o.val()) && i.addClass("is-empty"), i.append("<span class='material-input'></span>"), i.find("input[type=file]").length > 0 && i.addClass("is-fileinput")
            })
        },
        attachInputEventHandlers: function () {
            var n = this.options.validate;
            t(document).on("change", ".checkbox input[type=checkbox]", function () {
                t(this).blur()
            }).on("keydown paste", ".form-control", function (i) {
                o(i) && t(this).closest(".form-group").removeClass("is-empty")
            }).on("keyup change", ".form-control", function () {
                var o = t(this),
                    i = o.closest(".form-group"),
                    e = "undefined" == typeof o[0].checkValidity || o[0].checkValidity();
                "" === o.val() ? i.addClass("is-empty") : i.removeClass("is-empty"), n && (e ? i.removeClass("has-error") : i.addClass("has-error"))
            }).on("focus", ".form-control, .form-group.is-fileinput", function () {
                i(this)
            }).on("blur", ".form-control, .form-group.is-fileinput", function () {
                e(this)
            }).on("change", ".form-group input", function () {
                var o = t(this);
                if ("file" != o.attr("type")) {
                    var i = o.closest(".form-group"),
                        n = o.val();
                    n ? i.removeClass("is-empty") : i.addClass("is-empty")
                }
            }).on("change", ".form-group.is-fileinput input[type='file']", function () {
                var o = t(this),
                    i = o.closest(".form-group"),
                    n = "";
                t.each(this.files, function (t, o) {
                    n += o.name + ", "
                }), n = n.substring(0, n.length - 2), n ? i.removeClass("is-empty") : i.addClass("is-empty"), i.find("input.form-control[readonly]").val(n)
            })
        },
        ripples: function (o) {
            t(o ? o : this.options.withRipples).ripples()
        },
        autofill: function () {
            var o = setInterval(function () {
                t("input[type!=checkbox]").each(function () {
                    var o = t(this);
                    o.val() && o.val() !== o.attr("value") && o.trigger("change")
                })
            }, 100);
            setTimeout(function () {
                clearInterval(o)
            }, 1e4)
        },
        attachAutofillEventHandlers: function () {
            var o;
            t(document).on("focus", "input", function () {
                var i = t(this).parents("form").find("input").not("[type=file]");
                o = setInterval(function () {
                    i.each(function () {
                        var o = t(this);
                        o.val() !== o.attr("value") && o.trigger("change")
                    })
                }, 100)
            }).on("blur", ".form-group input", function () {
                clearInterval(o)
            })
        },
        init: function (o) {
            this.options = t.extend({}, this.options, o);
            var i = t(document);
            t.fn.ripples && this.options.ripples && this.ripples(), this.options.input && (this.input(), this.attachInputEventHandlers()), this.options.checkbox && this.checkbox(), this.options.togglebutton && this.togglebutton(), this.options.radio && this.radio(), this.options.autofill && (this.autofill(), this.attachAutofillEventHandlers()), document.arrive && this.options.arrive && (t.fn.ripples && this.options.ripples && i.arrive(this.options.withRipples, function () {
                t.material.ripples(t(this))
            }), this.options.input && i.arrive(this.options.inputElements, function () {
                t.material.input(t(this))
            }), this.options.checkbox && i.arrive(this.options.checkboxElements, function () {
                t.material.checkbox(t(this))
            }), this.options.radio && i.arrive(this.options.radioElements, function () {
                t.material.radio(t(this))
            }), this.options.togglebutton && i.arrive(this.options.togglebuttonElements, function () {
                t.material.togglebutton(t(this))
            }))
        }
    }
}(jQuery),
    function (t, o, i, n) {
        "use strict";

        function e(o, i) {
            r = this, this.element = t(o), this.options = t.extend({}, s, i), this._defaults = s, this._name = a, this.init()
        }
        var a = "ripples",
            r = null,
            s = {};
        e.prototype.init = function () {
            var i = this.element;
            i.on("mousedown touchstart", function (n) {
                if (!r.isTouch() || "mousedown" !== n.type) {
                    i.find(".ripple-container").length || i.append('<div class="ripple-container"></div>');
                    var e = i.children(".ripple-container"),
                        a = r.getRelY(e, n),
                        s = r.getRelX(e, n);
                    if (a || s) {
                        var l = r.getRipplesColor(i),
                            p = t("<div></div>");
                        p.addClass("ripple").css({
                            left: s,
                            top: a,
                            "background-color": l
                        }), e.append(p),
                            function () {
                                return o.getComputedStyle(p[0]).opacity
                            }(), r.rippleOn(i, p), setTimeout(function () {
                                r.rippleEnd(p)
                            }, 500), i.on("mouseup mouseleave touchend", function () {
                                p.data("mousedown", "off"), "off" === p.data("animating") && r.rippleOut(p)
                            })
                    }
                }
            })
        }, e.prototype.getNewSize = function (t, o) {
            return Math.max(t.outerWidth(), t.outerHeight()) / o.outerWidth() * 2.5
        }, e.prototype.getRelX = function (t, o) {
            var i = t.offset();
            return r.isTouch() ? (o = o.originalEvent, 1 === o.touches.length ? o.touches[0].pageX - i.left : !1) : o.pageX - i.left
        }, e.prototype.getRelY = function (t, o) {
            var i = t.offset();
            return r.isTouch() ? (o = o.originalEvent, 1 === o.touches.length ? o.touches[0].pageY - i.top : !1) : o.pageY - i.top
        }, e.prototype.getRipplesColor = function (t) {
            var i = t.data("ripple-color") ? t.data("ripple-color") : o.getComputedStyle(t[0]).color;
            return i
        }, e.prototype.hasTransitionSupport = function () {
            var t = i.body || i.documentElement,
                o = t.style,
                e = o.transition !== n || o.WebkitTransition !== n || o.MozTransition !== n || o.MsTransition !== n || o.OTransition !== n;
            return e
        }, e.prototype.isTouch = function () {
            return /Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)
        }, e.prototype.rippleEnd = function (t) {
            t.data("animating", "off"), "off" === t.data("mousedown") && r.rippleOut(t)
        }, e.prototype.rippleOut = function (t) {
            t.off(), r.hasTransitionSupport() ? t.addClass("ripple-out") : t.animate({
                opacity: 0
            }, 100, function () {
                t.trigger("transitionend")
            }), t.on("transitionend webkitTransitionEnd oTransitionEnd MSTransitionEnd", function () {
                t.remove()
            })
        }, e.prototype.rippleOn = function (t, o) {
            var i = r.getNewSize(t, o);
            r.hasTransitionSupport() ? o.css({
                "-ms-transform": "scale(" + i + ")",
                "-moz-transform": "scale(" + i + ")",
                "-webkit-transform": "scale(" + i + ")",
                transform: "scale(" + i + ")"
            }).addClass("ripple-on").data("animating", "on").data("mousedown", "on") : o.animate({
                width: 2 * Math.max(t.outerWidth(), t.outerHeight()),
                height: 2 * Math.max(t.outerWidth(), t.outerHeight()),
                "margin-left": -1 * Math.max(t.outerWidth(), t.outerHeight()),
                "margin-top": -1 * Math.max(t.outerWidth(), t.outerHeight()),
                opacity: .2
            }, 500, function () {
                o.trigger("transitionend")
            })
        }, t.fn.ripples = function (o) {
            return this.each(function () {
                t.data(this, "plugin_" + a) || t.data(this, "plugin_" + a, new e(this, o))
            })
        }
    }(jQuery, window, document);