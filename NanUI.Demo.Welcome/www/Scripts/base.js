/// <reference path="jquery-2.2.3.js" />
var $client;

(function ($client) {
	var runtimeLoaded = false;
	var hamburgButton,body,container,navCommands,panes;
	function initSysCommands() {

		$(window).on('windowstatechanged', function (e) {
			var el = $('.-nanui-maximize');
			if (e.detail.state == 2) {
				el.text('\u0032');
			}
			else {
				el.text('\u0031');
			}
		});
	}

	function disableMenuNSelection() {
		function handler(e) {
			if (e.srcElement.tagName === 'INPUT') {
				var target = e.srcElement;
				var t = target.type;
				if (t != "text" && t != "password" && t != "textarea") {
					return false;
				}
			}
			else {
				return false;
			}
		}
		$(document.body).on("selectstart", function (e) { return handler(event); });
		$(document.body).on("contextmenu", function (e) { return handler(event); });

	}

	function initHumbergButton() {
		hamburgButton.click(function (e) {
			body.toggleClass('aside-expanded');
			


			if (body.hasClass('aside-expanded')) {
				e.stopPropagation();

				body.one('click', function () {
					body.removeClass('aside-expanded');
				});
			}

		});
	}

	function initNavButton()
	{
		navCommands.click(function (e) {
			var btn = $(this);
			var page = btn.data('page');

			if (page) {
				var idx = btn.data('page-index');
				panes = container.find('.ui-pane');
				var selectedPane = panes.filter('.active');
				var selectedIndex = panes.index(selectedPane);

				if (idx != selectedIndex) {
					selectedPane.removeClass('active');
					var activePane = panes.filter(':eq(' + idx + ')').addClass('active');

					if (activePane.attr('id') == 'webgl-pane')
					{
						activePane.append($('<iframe src="microsurface.html" style="height:100%; width:100%;border:0;"></iframe>'));
					}
					else {
						$('#webgl-pane').empty();
					}

					if (activePane.attr('id') == 'flash-pane') {
						activePane.append($('<object type="application/x-shockwave-flash" class="player" data="http://static.hdslb.com/play.swf" width="100%" height="100%" id="player_placeholder" style="visibility: visible;"><param name="bgcolor" value="#ffffff"><param name="allowfullscreeninteractive" value="false"><param name="allowfullscreen" value="false"><param name="quality" value="high"><param name="allowscriptaccess" value="always"><param name="wmode" value="direct"><param name="flashvars" value="cid=5236468&amp;aid=3312266&amp;pre_ad=0"></object>'));
					}
					else {
						$('#flash-pane').empty();
					}

					if (activePane.attr('id') == 'video-pane')
					{
						activePane.append($('<video style="width:100%;height:100%;object-fit: cover;" preload="auto" autoplay="autoplay" translate="yes"><source src="http://www.ohtrip.cn/media/video/big_buck_bunny_480p_stereo.ogg" type="video/ogg" /></video>'));
					}
					else {
						$('#video-pane').empty();
					}
					if (activePane.attr('id') == 'css3-pane')
					{
						activePane.html('<div class="stage"><div class="nightOverlay"></div><div class="skyline"></div><div class="beans"></div><div class="ground back"></div><div class="ground mid"></div><div class="ground front"></div><div class="cloud large"></div><div class="cloud small"></div><div class="cloud medium"></div><div class="balloon"></div><div class="dowEventCenter"></div><div class="planetarium"></div><div class="friendshipShell"></div><div class="glockenspiel"></div><div class="rotation"><div class="sun"></div><div class="moon"></div></div></div>');
					}
					else {
						$('#css3-pane').empty();
					}
				}
			}


		});
	}

	function initPackingAreaPane() {
		$('#btnNewArea').click(function (e) {
			e.preventDefault();
			e.stopPropagation();
			showAboutForm();
		});

		$('#btnGC').click(function (e) {
			e.preventDefault();
			gcCollect();
		});

		$('#btnReload').click(function (e) {
			e.preventDefault();
			window.location.href = window.location.href;
		});

		$('#btnShowDevTools').click(function (e) {
			e.preventDefault();
			showDevTools();
		});
	}

	function setRuntimeInfo(cefRuntimeInfo) {
		var lst = $('#runtimeInfoList');

		//lst.empty();


		if (typeof cefRuntimeInfo != 'undefined') {
			
			
			lst.append($('<li></li>').append($('<span></span>').text('API Hash[0]：')).append($('<span class="badge"></span>').text(cefRuntimeInfo.api[0])));

			lst.append($('<li></li>').append($('<span></span>').text('API Hash[1]：')).append($('<span class="badge"></span>').text(cefRuntimeInfo.api[1])));
			lst.append($('<li></li>').append($('<span></span>').text('CEF版本：')).append($('<span class="badge"></span>').text(cefRuntimeInfo.cef)));

			lst.append($('<li></li>').append($('<span></span>').text('Chrome版本：')).append($('<span class="badge"></span>').text(cefRuntimeInfo.chrome)));

			lst.append($('<li></li>').append($('<span></span>').text('架构：')).append($('<span class="badge"></span>').text(cefRuntimeInfo.os + ' ' + cefRuntimeInfo.arch)));

			runtimeLoaded = true

		}
		else {
			lst.append($('<li></li>').text('暂时无法获取信息。'));
		}
	}

	$client.setRuntimeInfo = setRuntimeInfo;





	jQuery(function () {
		disableMenuNSelection();
		body = $(document.body);
		container = $('.ui-main-container');
		hamburgButton = $('.ui-nav-hamburg-btn');
		navCommands = $('.ui-nav-commands > span');
		panes = container.find('.ui-pane');
		initSysCommands();
		initHumbergButton();
		initNavButton();
		initPackingAreaPane();
	});
})($client || ($client = {}));


