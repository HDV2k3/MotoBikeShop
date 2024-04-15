!function (e) {
    var o = {};
    function t(i) {
        if (o[i])
            return o[i].exports;
        var n = o[i] = {
            i: i,
            l: !1,
            exports: {}
        };
        return e[i].call(n.exports, n, n.exports, t),
            n.l = !0,
            n.exports
    }
    t.m = e,
        t.c = o,
        t.d = function (e, o, i) {
            t.o(e, o) || Object.defineProperty(e, o, {
                enumerable: !0,
                get: i
            })
        }
        ,
        t.r = function (e) {
            "undefined" != typeof Symbol && Symbol.toStringTag && Object.defineProperty(e, Symbol.toStringTag, {
                value: "Module"
            }),
                Object.defineProperty(e, "__esModule", {
                    value: !0
                })
        }
        ,
        t.t = function (e, o) {
            if (1 & o && (e = t(e)),
                8 & o)
                return e;
            if (4 & o && "object" == typeof e && e && e.__esModule)
                return e;
            var i = Object.create(null);
            if (t.r(i),
                Object.defineProperty(i, "default", {
                    enumerable: !0,
                    value: e
                }),
                2 & o && "string" != typeof e)
                for (var n in e)
                    t.d(i, n, function (o) {
                        return e[o]
                    }
                        .bind(null, n));
            return i
        }
        ,
        t.n = function (e) {
            var o = e && e.__esModule ? function () {
                return e.default
            }
                : function () {
                    return e
                }
                ;
            return t.d(o, "a", o),
                o
        }
        ,
        t.o = function (e, o) {
            return Object.prototype.hasOwnProperty.call(e, o)
        }
        ,
        t.p = "/",
        t(t.s = 13)
}({
    13: function (e, o, t) {
        e.exports = t(14)
    },
    14: function (e, o) {
        $(document).ready((function () {
            var e = 800
                , o = 0
                , t = 0
                , i = 10
                , n = 0
                , c = 5
                , a = !1
                , s = !0
                , l = !1;
            function r() {
                s = !1;
                var n = $(".homepage-product-slide-tab").width()
                    , c = 0;
                o < 768 && (c = n + 30 - ($(".homepage-product-slide-show").width() - n) / 2),
                    t < i ? (t++,
                        $(".homepage-product-slide-child").animate({
                            left: -(t * (n + 28) + 15 + c)
                        }, e, (function () {
                            s = !0
                        }
                        ))) : ($(".homepage-product-slide-child").animate({
                            left: -15 - c
                        }, 0, (function () {
                            s = !0
                        }
                        )),
                            t = 1,
                            $(".homepage-product-slide-child").animate({
                                left: -(t * (n + 28) + 15 + c)
                            }, e, (function () {
                                s = !0
                            }
                            )))
            }
            function d(e) {
                0 == n ? $("#operation-back").hide() : $("#operation-back").show(),
                    n >= c - 2 + e ? $("#operation-next").hide() : $("#operation-next").show()
            }
            function p() {
                $("#homepage-product-slide-child-id").css({
                    visibility: "unset"
                }),
                    $("#homepage-product-slide-child-oto-id").css({
                        visibility: "hidden"
                    }),
                    $("#select_xe-may").css({
                        display: "flex"
                    }),
                    $("#select_o-to").css({
                        display: "none"
                    }),
                    0 == $("#homepage-product-slide-child-id.homepage-product-slide-tab-ctn").length ? $(".empty-list").addClass("show") : $(".empty-list").removeClass("show")
            }
            function u() {
                $("#homepage-product-slide-child-id").css({
                    visibility: "hidden"
                }),
                    $("#homepage-product-slide-child-oto-id").css({
                        visibility: "unset"
                    }),
                    $("#select_xe-may").css({
                        display: "none"
                    }),
                    $("#select_o-to").css({
                        display: "flex"
                    }),
                    0 == $("#homepage-product-slide-child-oto-id.homepage-product-slide-tab-ctn").length ? $(".empty-list").addClass("show") : $(".empty-list").removeClass("show")
            }
            $("#product-next").click((function () {
                s && r()
            }
            )),
                $("#product-back").click((function () {
                    s && function () {
                        s = !1;
                        var n = $(".homepage-product-slide-tab").width()
                            , c = 0;
                        o < 768 && (c = n + 30 - ($(".homepage-product-slide-show").width() - n) / 2);
                        t > 0 ? (t--,
                            $(".homepage-product-slide-child").animate({
                                left: -(t * (n + 28) + 15 + c)
                            }, e, (function () {
                                s = !0
                            }
                            ))) : ($(".homepage-product-slide-child").animate({
                                left: -(i * (n + 28) + 15 + c)
                            }, 0, (function () {
                                s = !0
                            }
                            )),
                                t = i - 1,
                                $(".homepage-product-slide-child").animate({
                                    left: -(t * (n + 28) + 15 + c)
                                }, e, (function () {
                                    s = !0
                                }
                                )))
                    }()
                }
                )),
                $("#operation-next").click((function () {
                    var t = 0
                        , i = c * ($(".homepage-operation-slide-tab").width() + 30) - $(".homepage-operation-slide-show").width() + 30;
                    o < 768 && (t = 1,
                        i += 30);
                    ++n < c - 2 + t ? $(".homepage-operation-slide-child").animate({
                        left: -n * ($(".homepage-operation-slide-tab").width() + 30)
                    }, e) : ($(".homepage-operation-slide-child").animate({
                        left: -(i - 60)
                    }, e),
                        n > c - 2 + t && (n = c - 2 + t));
                    d(t)
                }
                )),
                $("#operation-back").click((function () {
                    n > 0 && n--;
                    $(".homepage-operation-slide-child").animate({
                        left: -n * ($(".homepage-operation-slide-tab").width() + 30)
                    }, e),
                        d()
                }
                )),
                setInterval((function () {
                    a || r()
                }
                ), 5e3),
                $("#operation-back").hide(),
                $("#homepage-button-xe-may").css({
                    color: "#CC0000",
                    borderColor: "#CC0000"
                }),
                $("#homepage-button-xe-may").click((function () {
                    l = !1,
                        $("#homepage-button-xe-may").css({
                            color: "#CC0000",
                            borderColor: "#CC0000"
                        }),
                        $("#homepage-button-o-to").css({
                            color: "#707070",
                            borderColor: "#707070"
                        }),
                        p()
                }
                )),
                $("#homepage-button-o-to").click((function () {
                    l = !0,
                        $("#homepage-button-xe-may").css({
                            color: "#707070",
                            borderColor: "#707070"
                        }),
                        $("#homepage-button-o-to").css({
                            color: "#CC0000",
                            borderColor: "#CC0000"
                        }),
                        u()
                }
                )),
                $("#xe-may_redirect").click((function () {
                    l = !1,
                        $("#popup_enter_custom_popup").css({
                            display: "none"
                        }),
                        $("#homepage-button-xe-may").css({
                            color: "#CC0000",
                            borderColor: "#CC0000"
                        }),
                        $("#homepage-button-o-to").css({
                            color: "#707070",
                            borderColor: "#707070"
                        }),
                        p(),
                        $("#hp-mobile-select-xe-may").addClass("active"),
                        $("#hp-mobile-select-oto").removeClass("active"),
                        $(".hp-mobile-select-text").find("p").text("Xe máy"),
                        localStorage.setItem("show_popup_product", "1")
                }
                )),
                $("#o-to_redirect").click((function () {
                    l = !0,
                        $("#popup_enter_custom_popup").css({
                            display: "none"
                        }),
                        $("#homepage-button-xe-may").css({
                            color: "#707070",
                            borderColor: "#707070"
                        }),
                        $("#homepage-button-o-to").css({
                            color: "#CC0000",
                            borderColor: "#CC0000"
                        }),
                        u(),
                        $("#hp-mobile-select-oto").addClass("active"),
                        $("#hp-mobile-select-xe-may").removeClass("active"),
                        $(".hp-mobile-select-text").find("p").text("Ô TÔ"),
                        localStorage.setItem("show_popup_product", "1")
                }
                )),
                $("#homepage-option-oto-xe-may").change((function () {
                    "1" == $(this).val() ? p() : u()
                }
                )),
                $("#homepage-button-xe-may").mouseenter((function () {
                    $("#homepage-button-xe-may").css({
                        color: "#CC0000",
                        borderColor: "#CC0000"
                    })
                }
                )),
                $("#homepage-button-xe-may").mouseleave((function () {
                    l && $("#homepage-button-xe-may").css({
                        color: "#707070",
                        borderColor: "#707070"
                    })
                }
                )),
                $("#homepage-button-o-to").mouseenter((function () {
                    $("#homepage-button-o-to").css({
                        color: "#CC0000",
                        borderColor: "#CC0000"
                    })
                }
                )),
                $("#homepage-button-o-to").mouseleave((function () {
                    l || $("#homepage-button-o-to").css({
                        color: "#707070",
                        borderColor: "#707070"
                    })
                }
                )),
                $("#product-back, #product-next").mouseenter((function () {
                    a = !0
                }
                )),
                $("#product-back, #product-next").mouseleave((function () {
                    a = !1
                }
                )),
                $(".homepage-product-slide-tab").mouseenter((function () {
                    a = !0,
                        $(this).find(".homepage-product-slide-tab-detail").stop(),
                        $(this).find(".homepage-product-slide-tab-detail").animate({
                            bottom: 148,
                            opacity: .9
                        }, 300)
                }
                )),
                $(".homepage-product-slide-tab").mouseleave((function () {
                    a = !1,
                        $(this).find(".homepage-product-slide-tab-detail").stop(),
                        $(this).find(".homepage-product-slide-tab-detail").animate({
                            bottom: 80,
                            opacity: 0
                        }, 300)
                }
                )),
                $("#homepage-product-slide-child-id").css({
                    visibility: "unset"
                }),
                $(window).resize((function () {
                    o = $(this).width()
                }
                )).resize();
            var m = !1;
            $(".hp-mobile-select-text").click((function () {
                m ? h() : ($(this).addClass("active"),
                    $(this).find(".hp-mobile-select-item").animate({
                        deg: 180
                    }, {
                        step: function (e) {
                            $(this).find("i").css({
                                transform: "rotate(" + e + "deg)"
                            })
                        }
                    }),
                    $(".hp-mobile-select-menu").animate({
                        height: 92
                    }),
                    m = !0)
            }
            )),
                $("#hp-mobile-select-xe-may").click((function () {
                    $(this).addClass("active"),
                        $("#hp-mobile-select-oto").removeClass("active"),
                        $(".hp-mobile-select-text").find("p").text("XE MÁY"),
                        h(),
                        p()
                }
                )),
                $("#hp-mobile-select-oto").click((function () {
                    $(this).addClass("active"),
                        $("#hp-mobile-select-xe-may").removeClass("active"),
                        $(".hp-mobile-select-text").find("p").text("Ô TÔ"),
                        h(),
                        u()
                }
                ));
            var h = function () {
                $(".hp-mobile-select-item").animate({
                    deg: 0
                }, {
                    step: function (e) {
                        $(this).find("i").css({
                            transform: "rotate(" + e + "deg)"
                        })
                    },
                    complete: function () {
                        $(".hp-mobile-select-text").removeClass("active")
                    }
                }),
                    $(".hp-mobile-select-menu").animate({
                        height: 0
                    }),
                    m = !1
            }
        }
        ))
    }
});
