var KTDialer = function (e, t) {
	var n = this;
	if (e) {
		var i = {
			min: null,
			max: null,
			step: 1,
			decimals: 0,
			prefix: "",
			suffix: ""
		},
			r = function () {
				n.options = KTUtil.deepExtend({}, i, t), n.element = e, n.incElement = n.element.querySelector('[data-kt-dialer-control="increase"]'), n.decElement = n.element.querySelector('[data-kt-dialer-control="decrease"]'), n.inputElement = n.element.querySelector("input[type]"), d("decimals") && (n.options.decimals = parseInt(d("decimals"))), d("prefix") && (n.options.prefix = d("prefix")), d("suffix") && (n.options.suffix = d("suffix")), d("step") && (n.options.step = parseFloat(d("step"))), d("min") && (n.options.min = parseFloat(d("min"))), d("max") && (n.options.max = parseFloat(d("max"))), n.value = parseFloat(n.inputElement.value.replace(/[^\d.]/g, "")), s(), o(), KTUtil.data(n.element).set("dialer", n)
			},
			o = function () {
				KTUtil.addEvent(n.incElement, "click", (function (e) {
					e.preventDefault(), a()
				})), KTUtil.addEvent(n.decElement, "click", (function (e) {
					e.preventDefault(), l()
				})), KTUtil.addEvent(n.inputElement, "change", (function (e) {
					e.preventDefault(), s()
				}))
			},
			a = function () {
				return KTEventHandler.trigger(n.element, "kt.dialer.increase", n), n.inputElement.value = n.value + n.options.step, s(), KTEventHandler.trigger(n.element, "kt.dialer.increased", n), n
			},
			l = function () {
				return KTEventHandler.trigger(n.element, "kt.dialer.decrease", n), n.inputElement.value = n.value - n.options.step, s(), KTEventHandler.trigger(n.element, "kt.dialer.decreased", n), n
			},
			s = function () {
				KTEventHandler.trigger(n.element, "kt.dialer.change", n), n.value = parseFloat(n.inputElement.value.replace(/[^\d.]/g, "")), n.value < n.options.min && (n.value = n.options.min), n.value > n.options.max && (n.value = n.options.max), n.inputElement.value = u(n.value), KTEventHandler.trigger(n.element, "kt.dialer.changed", n)
			},
			u = function (e) {
				return n.options.prefix + parseFloat(e).toFixed(n.options.decimals) + n.options.suffix
			},
			d = function (e) {
				return !0 === n.element.hasAttribute("data-kt-dialer-" + e) ? n.element.getAttribute("data-kt-dialer-" + e) : null
			};
		!0 === KTUtil.data(e).has("dialer") ? n = KTUtil.data(e).get("dialer") : r(), n.increase = function () {
			return a()
		}, n.decrease = function () {
			return l()
		}, n.getElement = function () {
			return n.element
		}, n.destroy = function () {
			KTUtil.data(n.element).remove("dialer")
		}, n.on = function (e, t) {
			return KTEventHandler.on(n.element, e, t)
		}, n.one = function (e, t) {
			return KTEventHandler.one(n.element, e, t)
		}, n.off = function (e) {
			return KTEventHandler.off(n.element, e)
		}, n.trigger = function (e, t) {
			return KTEventHandler.trigger(n.element, e, t, n, t)
		}
	}
};
KTDialer.getInstance = function (e) {
	return null !== e && KTUtil.data(e).has("dialer") ? KTUtil.data(e).get("dialer") : null
}, KTDialer.createInstances = function (e = '[data-kt-dialer="true"]') {
	var t = document.body.querySelectorAll(e);
	if (t && t.length > 0)
		for (var n = 0, i = t.length; n < i; n++) new KTDialer(t[n])
	},
	KTDialer.init = function () {
	KTDialer.createInstances()
}, "loading" === document.readyState ? document.addEventListener("DOMContentLoaded", KTDialer.init) : KTDialer.init(), "undefined" != typeof module && void 0 !== module.exports && (module.exports = KTDialer);
var KTDrawer = function (e, t) {
	var n = this,
		i = document.getElementsByTagName("BODY")[0];
	if (null != e) {
		var r = {
			overlay: !0,
			direction: "end",
			baseClass: "drawer",
			overlayClass: "drawer-overlay"
		},
			o = function () {
				n.options = KTUtil.deepExtend({}, r, t), n.uid = KTUtil.getUniqueId("drawer"), n.element = e, n.overlayElement = null, n.name = n.element.getAttribute("data-kt-drawer-name"), n.shown = !1, n.lastWidth, n.toggleElement = null, n.element.setAttribute("data-kt-drawer", "true"), a(), d(), KTUtil.data(n.element).set("drawer", n)
			},
			a = function () {
				var e = f("toggle"),
					t = f("close");
				null !== e && e.length > 0 && KTUtil.on(i, e, "click", (function (e) {
					e.preventDefault(), n.toggleElement = this, l()
				})), null !== t && t.length > 0 && KTUtil.on(i, t, "click", (function (e) {
					e.preventDefault(), n.closeElement = this, s()
				}))
			},
			l = function () {
				!1 !== KTEventHandler.trigger(n.element, "kt.drawer.toggle", n) && (!0 === n.shown ? s() : u(), KTEventHandler.trigger(n.element, "kt.drawer.toggled", n))
			},
			s = function () {
				!1 !== KTEventHandler.trigger(n.element, "kt.drawer.hide", n) && (n.shown = !1, m(), i.removeAttribute("data-kt-drawer-" + n.name, "on"), i.removeAttribute("data-kt-drawer"), KTUtil.removeClass(n.element, n.options.baseClass + "-on"), null !== n.toggleElement && KTUtil.removeClass(n.toggleElement, "active"), KTEventHandler.trigger(n.element, "kt.drawer.after.hidden", n))
			},
			u = function () {
				!1 !== KTEventHandler.trigger(n.element, "kt.drawer.show", n) && (n.shown = !0, c(), i.setAttribute("data-kt-drawer-" + n.name, "on"), i.setAttribute("data-kt-drawer", "on"), KTUtil.addClass(n.element, n.options.baseClass + "-on"), null !== n.toggleElement && KTUtil.addClass(n.toggleElement, "active"), KTEventHandler.trigger(n.element, "kt.drawer.shown", n))
			},
			d = function () {
				var e = p(),
					t = f("direction");
				!0 === KTUtil.hasClass(n.element, n.options.baseClass + "-on") && "on" === String(i.getAttribute("data-kt-drawer-" + n.name + "-")) ? n.shown = !0 : n.shown = !1, !0 === f("activate") ? (KTUtil.addClass(n.element, n.options.baseClass), KTUtil.addClass(n.element, n.options.baseClass + "-" + t), KTUtil.css(n.element, "width", e, !0), n.lastWidth = e) : (KTUtil.css(n.element, "width", ""), KTUtil.removeClass(n.element, n.options.baseClass), KTUtil.removeClass(n.element, n.options.baseClass + "-" + t), s())
			},
			c = function () {
				!0 === f("overlay") && (n.overlayElement = document.createElement("DIV"), KTUtil.css(n.overlayElement, "z-index", KTUtil.css(n.element, "z-index") - 1), i.append(n.overlayElement), KTUtil.addClass(n.overlayElement, f("overlay-class")), KTUtil.addEvent(n.overlayElement, "click", (function (e) {
					e.preventDefault(), s()
				})))
			},
			m = function () {
				null !== n.overlayElement && KTUtil.remove(n.overlayElement)
			},
			f = function (e) {
				if (!0 === n.element.hasAttribute("data-kt-drawer-" + e)) {
					var t = n.element.getAttribute("data-kt-drawer-" + e),
						i = KTUtil.getResponsiveValue(t);
					return null !== i && "true" === String(i) ? i = !0 : null !== i && "false" === String(i) && (i = !1), i
				}
				var r = KTUtil.snakeToCamel(e);
				return n.options[r] ? KTUtil.getResponsiveValue(n.options[r]) : null
			},
			p = function () {
				var e = f("width");
				return "auto" === e && (e = KTUtil.css(n.element, "width")), e
			};
		KTUtil.data(e).has("drawer") ? n = KTUtil.data(e).get("drawer") : o(), n.toggle = function () {
			return l()
		}, n.show = function () {
			return u()
		}, n.hide = function () {
			return s()
		}, n.isShown = function () {
			return n.shown
		}, n.update = function () {
			d()
		}, n.goElement = function () {
			return n.element
		}, n.destroy = function () {
			KTUtil.data(n.element).remove("drawer")
		}, n.on = function (e, t) {
			return KTEventHandler.on(n.element, e, t)
		}, n.one = function (e, t) {
			return KTEventHandler.one(n.element, e, t)
		}, n.off = function (e) {
			return KTEventHandler.off(n.element, e)
		}, n.trigger = function (e, t) {
			return KTEventHandler.trigger(n.element, e, t, n, t)
		}
	}
};
KTDrawer.getInstance = function (e) {
	return null !== e && KTUtil.data(e).has("drawer") ? KTUtil.data(e).get("drawer") : null
}, KTDrawer.hideAll = function (e = null, t = '[data-kt-drawer="true"]') {
	var n = document.querySelectorAll(t);
	if (n && n.length > 0)
		for (var i = 0, r = n.length; i < r; i++) {
			var o = n[i],
				a = KTDrawer.getInstance(o);
			a && (e ? o !== e && a.hide() : a.hide())
		}
}, KTDrawer.updateAll = function (e = '[data-kt-drawer="true"]') {
	var t = document.querySelectorAll(e);
	if (t && t.length > 0)
		for (var n = 0, i = t.length; n < i; n++) {
			var r = t[n],
				o = KTDrawer.getInstance(r);
			o && o.update()
		}
}, KTDrawer.createInstances = function (e = '[data-kt-drawer="true"]') {
	var t = document.getElementsByTagName("BODY")[0].querySelectorAll(e);
	if (t && t.length > 0)
		for (var n = 0, i = t.length; n < i; n++) new KTDrawer(t[n])
}, KTDrawer.handleShow = function () {
	KTUtil.on(document.body, '[data-kt-drawer-show="true"][data-kt-drawer-target]', "click", (function (e) {
		var t = document.querySelector(this.getAttribute("data-kt-drawer-target"));
		t && KTDrawer.getInstance(t).show()
	}))
}, KTDrawer.handleDismiss = function () {
	KTUtil.on(document.body, '[data-kt-drawer-dismiss="true"]', "click", (function (e) {
		var t = this.closest('[data-kt-drawer="true"]');
		if (t) {
			var n = KTDrawer.getInstance(t);
			n.isShown() && n.hide()
		}
	}))
}, window.addEventListener("resize", (function () {
	var e = document.getElementsByTagName("BODY")[0];
	KTUtil.throttle(undefined, (function () {
		var t = e.querySelectorAll('[data-kt-drawer="true"]');
		if (t && t.length > 0)
			for (var n = 0, i = t.length; n < i; n++) {
				var r = KTDrawer.getInstance(t[n]);
				r && r.update()
			}
	}), 200)
})),
	KTDrawer.init = function () {
	KTDrawer.createInstances(), KTDrawer.handleShow(), KTDrawer.handleDismiss()
}, "loading" === document.readyState ? document.addEventListener("DOMContentLoaded", KTDrawer.init) : KTDrawer.init(), "undefined" != typeof module && void 0 !== module.exports && (module.exports = KTDrawer);



























//Menu

var KTMenu = function (e, t) {
	var n = this;
	if (null != e) {
		var i = {
			dropdown: {
				hoverTimeout: 200,
				zindex: 105
			},
			accordion: {
				slideSpeed: 250,
				expand: !1
			}
		},
			r = function () {
				n.options = KTUtil.deepExtend({}, i, t), n.uid = KTUtil.getUniqueId("menu"), n.element = e, n.triggerElement, n.element.setAttribute("data-kt-menu", "true"), d(), u(), KTUtil.data(n.element).set("menu", n)
			},
			o = function (e) {
				e || (e = n.triggerElement), !0 === m(e) ? l(e) : a(e)
			},
			a = function (e) {
				e || (e = n.triggerElement), !0 !== m(e) && ("dropdown" === v(e) ? E(e) : "accordion" === v(e) && S(e), KTUtil.data(e).set("type", v(e)))
			},
			l = function (e) {
				e || (e = n.triggerElement), !1 !== m(e) && ("dropdown" === v(e) ? w(e) : "accordion" === v(e) && A(e))
			},
			s = function (e) {
				if (!1 !== f(e)) {
					var t = g(e);
					KTUtil.data(e).has("type") && KTUtil.data(e).get("type") !== v(e) && (KTUtil.removeClass(e, "hover"), KTUtil.removeClass(e, "show"), KTUtil.removeClass(t, "show"))
				}
			},
			u = function () {
				var e = n.element.querySelectorAll(".menu-item[data-kt-menu-trigger]");
				if (e && e.length > 0)
					for (var t = 0, i = e.length; t < i; t++) s(e[t])
			},
			d = function () {
				var e = document.querySelector('[data-kt-menu-target="# ' + n.element.getAttribute("id") + '"]');
				null !== e ? n.triggerElement = e : n.element.closest("[data-kt-menu-trigger]") ? n.triggerElement = n.element.closest("[data-kt-menu-trigger]") : n.element.parentNode && KTUtil.child(n.element.parentNode, "[data-kt-menu-trigger]") && (n.triggerElement = KTUtil.child(n.element.parentNode, "[data-kt-menu-trigger]")), n.triggerElement && KTUtil.data(n.triggerElement).set("menu", n)
			},
			c = function (e) {
				return n.triggerElement === e
			},
			m = function (e) {
				var t = g(e);
				return null !== t && ("dropdown" === v(e) ? !0 === KTUtil.hasClass(t, "show") && !0 === t.hasAttribute("data-popper-placement") : KTUtil.hasClass(e, "show"))
			},
			f = function (e) {
				return KTUtil.hasClass(e, "menu-item") && e.hasAttribute("data-kt-menu-trigger")
			},
			p = function (e) {
				return KTUtil.child(e, ".menu-link")
			},
			g = function (e) {
				return !0 === c(e) ? n.element : !0 === e.classList.contains("menu-sub") ? e : KTUtil.data(e).has("sub") ? KTUtil.data(e).get("sub") : KTUtil.child(e, ".menu-sub")
			},
			v = function (e) {
				var t = g(e);
				return t && parseInt(KTUtil.css(t, "z-index")) > 0 ? "dropdown" : "accordion"
			},
			T = function (e) {
				var t, n;
				return c(e) || e.hasAttribute("data-kt-menu-trigger") ? e : KTUtil.data(e).has("item") ? KTUtil.data(e).get("item") : (t = e.closest(".menu-item[data-kt-menu-trigger]")) ? t : (n = e.closest(".menu-sub")) && !0 === KTUtil.data(n).has("item") ? KTUtil.data(n).get("item") : void 0
			},
			h = function (e) {
				var t, n = e.closest(".menu-sub");
				return KTUtil.data(n).has("item") ? KTUtil.data(n).get("item") : n && (t = n.closest(".menu-item[data-kt-menu-trigger]")) ? t : null
			},
			K = function (e) {
				var t = e;
				return KTUtil.data(e).get("sub") && (t = KTUtil.data(e).get("sub")), null !== t && t.querySelector(".menu-item[data-kt-menu-trigger]") || null
			},
			U = function (e) {
				var t, n = [],
					i = 0;
				do {
					(t = K(e)) && (n.push(t), e = t), i++
				} while (null !== t && i < 20);
				return n
			},
			E = function (e) {
				if (!1 !== KTEventHandler.trigger(n.element, "kt.menu.dropdown.show", e)) {
					KTMenu.hideDropdowns(e);
					c(e) || p(e);
					var t = g(e),
						i = x(e, "width"),
						r = x(e, "height"),
						o = n.options.dropdown.zindex,
						a = KTUtil.getHighestZindex(e);
					null !== a && a >= o && (o = a + 1), o > 0 && KTUtil.css(t, "z-index", o), null !== i && KTUtil.css(t, "width", i), null !== r && KTUtil.css(t, "height", r), KTUtil.css(t, "display", ""), KTUtil.css(t, "overflow", ""), b(e, t), KTUtil.addClass(e, "show"), KTUtil.addClass(e, "menu-dropdown"), KTUtil.addClass(t, "show"), !0 === x(e, "overflow") ? (document.body.appendChild(t), KTUtil.data(e).set("sub", t), KTUtil.data(t).set("item", e), KTUtil.data(t).set("menu", n)) : KTUtil.data(t).set("item", e), KTEventHandler.trigger(n.element, "kt.menu.dropdown.shown", e)
				}
			},
			w = function (e) {
				if (!1 !== KTEventHandler.trigger(n.element, "kt.menu.dropdown.hide", e)) {
					var t = g(e);
					KTUtil.css(t, "z-index", ""), KTUtil.css(t, "width", ""), KTUtil.css(t, "height", ""), KTUtil.removeClass(e, "show"), KTUtil.removeClass(e, "menu-dropdown"), KTUtil.removeClass(t, "show"), !0 === x(e, "overflow") && (e.classList.contains("menu-item") ? e.appendChild(t) : KTUtil.insertAfter(n.element, e), KTUtil.data(e).remove("sub"), KTUtil.data(t).remove("item"), KTUtil.data(t).remove("menu")), k(e), KTEventHandler.trigger(n.element, "kt.menu.dropdown.hidden", e)
				}
			},
			b = function (e, t) {
				var n, i = x(e, "attach");
				n = i ? "parent" === i ? e.parentNode : document.querySelector(i) : e;
				var r = Popper.createPopper(n, t, y(e));
				KTUtil.data(e).set("popper", r)
			},
			k = function (e) {
				!0 === KTUtil.data(e).has("popper") && (KTUtil.data(e).get("popper").destroy(), KTUtil.data(e).remove("popper"))
			},
			y = function (e) {
				var t = x(e, "placement");
				t || (t = "right");
				var n = x(e, "offset"),
					i = n ? n.split(",") : [];
				return {
					placement: t,
					strategy: !0 === x(e, "overflow") ? "absolute" : "fixed",
					modifiers: [{
						name: "offset",
						options: {
							offset: i
						}
					}, {
						name: "preventOverflow",
						options: {
							altAxis: !1 !== x(e, "flip")
						}
					}, {
						name: "flip",
						options: {
							flipVariations: !1
						}
					}]
				}
			},
			S = function (e) {
				if (!1 !== KTEventHandler.trigger(n.element, "kt.menu.accordion.show", e)) {
					!1 === n.options.accordion.expand && I(e);
					var t = g(e);
					!0 === KTUtil.data(e).has("popper") && w(e), KTUtil.addClass(e, "hover"), KTUtil.addClass(e, "showing"), KTUtil.slideDown(t, n.options.accordion.slideSpeed, (function () {
						KTUtil.removeClass(e, "showing"), KTUtil.addClass(e, "show"), KTUtil.addClass(t, "show"), KTEventHandler.trigger(n.element, "kt.menu.accordion.shown", e)
					}))
				}
			},
			A = function (e) {
				if (!1 !== KTEventHandler.trigger(n.element, "kt.menu.accordion.hide", e)) {
					var t = g(e);
					KTUtil.addClass(e, "hiding"), KTUtil.slideUp(t, n.options.accordion.slideSpeed, (function () {
						KTUtil.removeClass(e, "hiding"), KTUtil.removeClass(e, "show"), KTUtil.removeClass(t, "show"), KTUtil.removeClass(e, "hover"), KTEventHandler.trigger(n.element, "kt.menu.accordion.hidden", e)
					}))
				}
			},
			I = function (e) {
				var t, i = KTUtil.findAll(n.element, ".show[data-kt-menu-trigger]");
				if (i && i.length > 0)
					for (var r = 0, o = i.length; r < o; r++) t = i[r], "accordion" === v(t) && t !== e && !1 === e.contains(t) && !1 === t.contains(e) && A(t)
			},
			x = function (e, t) {
				var n, i = null;
				return e && e.hasAttribute("data-kt-menu-" + t) && (n = e.getAttribute("data-kt-menu-" + t), null !== (i = KTUtil.getResponsiveValue(n)) && "true" === String(i) ? i = !0 : null !== i && "false" === String(i) && (i = !1)), i
			};
		!0 === KTUtil.data(e).has("menu") ? n = KTUtil.data(e).get("menu") : r(), n.click = function (e, t) {
			return function (e, t) {
				t.preventDefault();
				var n = T(e);
				"click" === x(n, "trigger") && (!1 === x(n, "toggle") ? a(n) : o(n))
			}(e, t)
		}, n.link = function (e, t) {
			!1 !== KTEventHandler.trigger(n.element, "kt.menu.link.click", n) && (KTMenu.hideDropdowns(), KTEventHandler.trigger(n.element, "kt.menu.link.clicked", n))
		}, n.dismiss = function (e, t) {
			return function (e, t) {
				var n = T(e),
					i = U(n);
				if (null !== n && "dropdown" === v(n) && (l(n), i.length > 0))
					for (var r = 0, o = i.length; r < o; r++) null !== i[r] && "dropdown" === v(i[r]) && l(tems[r])
			}(e)
		}, n.mouseover = function (e, t) {
			return function (e, t) {
				var n = T(e);
				null !== n && "hover" === x(n, "trigger") && ("1" === KTUtil.data(n).get("hover") && (clearTimeout(KTUtil.data(n).get("timeout")), KTUtil.data(n).remove("hover"), KTUtil.data(n).remove("timeout")), a(n))
			}(e)
		}, n.mouseout = function (e, t) {
			return function (e, t) {
				var i = T(e);
				if (null !== i && "hover" === x(i, "trigger")) {
					var r = setTimeout((function () {
						"1" === KTUtil.data(i).get("hover") && l(i)
					}), n.options.dropdown.hoverTimeout);
					KTUtil.data(i).set("hover", "1"), KTUtil.data(i).set("timeout", r)
				}
			}(e)
		}, n.getItemTriggerType = function (e) {
			return x(e, "trigger")
		}, n.getItemSubType = function (e) {
			return v(e)
		}, n.show = function (e) {
			return a(e)
		}, n.hide = function (e) {
			return l(e)
		}, n.reset = function (e) {
			return s(e)
		}, n.update = function () {
			return u()
		}, n.getElement = function () {
			return n.element
		}, n.getItemLinkElement = function (e) {
			return p(e)
		}, n.getItemToggleElement = function (e) {
			return function (e) {
				return n.triggerElement ? n.triggerElement : p(e)
			}(e)
		}, n.getItemSubElement = function (e) {
			return g(e)
		}, n.getItemParentElements = function (e) {
			return function (e) {
				var t, i = [],
					r = 0;
				do {
					(t = h(e)) && (i.push(t), e = t), r++
				} while (null !== t && r < 20);
				return n.triggerElement && i.unshift(n.triggerElement), i
			}(e)
		}, n.isItemSubShown = function (e) {
			return m(e)
		}, n.isItemParentShown = function (e) {
			return function (e) {
				return KTUtil.parents(e, ".menu-item.show").length > 0
			}(e)
		}, n.getTriggerElement = function () {
			return n.triggerElement
		}, n.isItemDropdownPermanent = function (e) {
			return function (e) {
				return !0 === x(e, "permanent")
			}(e)
		}, n.destroy = function () {
			KTUtil.data(n.element).remove("menu")
		}, n.hideAccordions = function (e) {
			return I(e)
		}, n.on = function (e, t) {
			return KTEventHandler.on(n.element, e, t)
		}, n.one = function (e, t) {
			return KTEventHandler.one(n.element, e, t)
		}, n.off = function (e) {
			return KTEventHandler.off(n.element, e)
		}
	}
};
KTMenu.getInstance = function (e) {
	var t;
	if (KTUtil.data(e).has("menu")) return KTUtil.data(e).get("menu");
	if ((t = e.closest(".menu")) && KTUtil.data(t).has("menu")) return KTUtil.data(t).get("menu");
	if (KTUtil.hasClass(e, "menu-link")) {
		var n = e.closest(".menu-sub");
		if (KTUtil.data(n).has("menu")) return KTUtil.data(n).get("menu")
	}
	return null
}, KTMenu.hideDropdowns = function (e) {
	var t = document.querySelectorAll(".show.menu-dropdown[data-kt-menu-trigger]");
	if (t && t.length > 0)
		for (var n = 0, i = t.length; n < i; n++) {
			var r = t[n],
				o = KTMenu.getInstance(r);
			o && "dropdown" === o.getItemSubType(r) && (e ? !1 === o.getItemSubElement(r).contains(e) && !1 === r.contains(e) && r !== e && o.hide(r) : o.hide(r))
		}
}, KTMenu.updateDropdowns = function () {
	var e = document.querySelectorAll(".show.menu-dropdown[data-kt-menu-trigger]");
	if (e && e.length > 0)
		for (var t = 0, n = e.length; t < n; t++) {
			var i = e[t];
			KTUtil.data(i).has("popper") && KTUtil.data(i).get("popper").forceUpdate()
		}
}, KTMenu.initGlobalHandlers = function () {
	document.addEventListener("click", (function (e) {
		var t, n, i, r = document.querySelectorAll(".show.menu-dropdown[data-kt-menu-trigger]");
		if (r && r.length > 0)
			for (var o = 0, a = r.length; o < a; o++)
				if (t = r[o], (i = KTMenu.getInstance(t)) && "dropdown" === i.getItemSubType(t)) {
					if (i.getElement(), n = i.getItemSubElement(t), t === e.target || t.contains(e.target)) continue;
					if (n === e.target || n.contains(e.target)) continue;
					i.hide(t)
				}
	})), KTUtil.on(document.body, '.menu-item[data-kt-menu-trigger] > .menu-link, [data-kt-menu-trigger]:not(.menu-item):not([data-kt-menu-trigger="auto"])', "click", (function (e) {
		var t = KTMenu.getInstance(this);
		if (null !== t) return t.click(this, e)
	})), KTUtil.on(document.body, ".menu-item:not([data-kt-menu-trigger]) > .menu-link", "click", (function (e) {
		var t = KTMenu.getInstance(this);
		if (null !== t) return t.link(this, e)
	})), KTUtil.on(document.body, '[data-kt-menu-dismiss="true"]', "click", (function (e) {
		var t = KTMenu.getInstance(this);
		if (null !== t) return t.dismiss(this, e)
	})), KTUtil.on(document.body, "[data-kt-menu-trigger], .menu-sub", "mouseover", (function (e) {
		var t = KTMenu.getInstance(this);
		if (null !== t && "dropdown" === t.getItemSubType(this)) return t.mouseover(this, e)
	})), KTUtil.on(document.body, "[data-kt-menu-trigger], .menu-sub", "mouseout", (function (e) {
		var t = KTMenu.getInstance(this);
		if (null !== t && "dropdown" === t.getItemSubType(this)) return t.mouseout(this, e)
	})), window.addEventListener("resize", (function () {
		var e;
		KTUtil.throttle(undefined, (function () {
			var t = document.querySelectorAll('[data-kt-menu="true"]');
			if (t && t.length > 0)
				for (var n = 0, i = t.length; n < i; n++)(e = KTMenu.getInstance(t[n])) && e.update()
		}), 200)
	}))
}, KTMenu.createInstances = function (e = '[data-kt-menu="true"]') {
	var t = document.querySelectorAll(e);
	if (t && t.length > 0)
		for (var n = 0, i = t.length; n < i; n++) new KTMenu(t[n])
}, KTMenu.init = function () {
	KTMenu.initGlobalHandlers(), KTMenu.createInstances()
}, "loading" === document.readyState ? document.addEventListener("DOMContentLoaded", KTMenu.init) : KTMenu.init(), "undefined" != typeof module && void 0 !== module.exports && (module.exports = KTMenu);

