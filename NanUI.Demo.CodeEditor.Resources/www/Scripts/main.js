/// <reference path="../lib/codemirror.js" />
/// <reference path="jquery-2.2.3.js" />
/// <reference path="../addon/mode/loadmode.js" />

var CodeEditor;

(function (editor) {

	var instance;

	var openButton, saveButton, newButton;

	var headerTitle;

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

	//获取当前CodeMirror实例
	editor.getCodeMirrorInstance = function () {
		return instance;
	};

	//获得文本框文件
	editor.getContent = function () {
		if (instance) {
			return instance.doc.getValue();
		}
	};

	//直接设置文本框内容
	editor.setContent = function (content,mode,clean) {
		if (instance)
		{
			instance.setValue(content);
			changeCodeScheme(mode);

			if(clean)
			{
				instance.doc.markClean();
			}
		}
	};

	//新建文档
	editor.setNew = function () {
		if (instance) {
			instance.doc.setValue('');
			instance.doc.markClean();
			if (typeof hostEditor != 'undefined')	//hostEditor就是从C#里面暴露过来的对象，下同。
			{
				hostEditor.setClean(true);
			}
		}
	}

	//禁用上下文菜单事件
	//禁用选择事件
	//当然，要判断一下先，能选择的地方还是得能选择才行。
	function disableMenuNSelection() {
		function handler(e) {

			var target = e.srcElement;

			while (typeof target.tagName == 'undefined')
			{
				target = target.parentElement;
			}

			if (e.srcElement.tagName === 'INPUT') {

				var t = target.type;
				if (t != "text" && t != "password" && t != "textarea") {
					return false;
				}
			}
			else {
				if ($(target).closest('.CodeMirror-code').length || $(target).closest('.CodeMirror-line').length)
				{ 
					return true;
				}
				else {
					return false;
				}
				
			}
		}
		$(document.body).on("selectstart", function (e) { return handler(event); });
		$(document.body).on("contextmenu", function (e) { return handler(event); });

	}

	//更改当前视图的代码模式
	function changeCodeScheme(extensionName) {
		if (extensionName)
		{
			var info = CodeMirror.findModeByExtension(extensionName);
			if (info)
			{
				var mode = info.mode;
				var spec = info.mime;

				if (mode) {
					instance.setOption('mode', spec);
					CodeMirror.autoLoadMode(instance, mode);

				}
			}
		}
	}

	CodeEditor.changeCodeScheme = changeCodeScheme;

	//初始化工具栏那三个按钮
	function initToolbarButtons() {
		newButton = $('#btnNew');
		openButton = $('#btnOpen');
		saveButton = $('#btnSave');


		newButton.click(function () {
			if (typeof hostEditor != 'undefined') {
				hostEditor.newFile();	//调用C#对象的newFile方法
			}

			instance.focus();
		});

		openButton.click(function () {
			if (typeof hostEditor != 'undefined')
			{
				var content = hostEditor.openFile();	//调用C#对象的openFile方法

				if (content != null)
				{
					instance.doc.setValue(content);
				}
			}

			instance.focus();
		});

		saveButton.click(function () {
			if (typeof hostEditor != 'undefined')
			{
				//调用C#对象的saveFile方法
				if (hostEditor.saveFile()) {
					markClean();

				}
			}
			
			instance.focus();
		});


		$('#btnAbout').click(function () {

			if (typeof hostEditor != 'undefined')
			{
				hostEditor.showAbout();
			}

		});

		$('#btnDevTools').click(function () {

			if (typeof hostEditor != 'undefined') {
				hostEditor.showDevTools();
			}

		});
	}

	//标记CodeMirror为干净的，后台就不会触发询问是否保存的对话框
	function markClean()
	{
		instance.doc.markClean();
		if (typeof hostEditor != 'undefined') {
			hostEditor.setClean(instance.isClean());
		}
	}

	//设置当前窗口的标题
	function setTitle(str) {
		if (str) {
			headerTitle.text(' - ' + str);
		}
		else {
			headerTitle.text('');
		}
	}

	editor.setTitle = setTitle;
	

	$(function () {

		disableMenuNSelection();
		initSysCommands();
		headerTitle = $('#header-title > span');

		CodeMirror.modeURL = "../mode/%N/%N.js";

		instance = CodeMirror.fromTextArea(document.getElementById("code-editor"), {
			lineNumbers: true,
			lineWrapping: true,
			matchBrackets: true,
			autoCloseBrackets: true,
			indentUnit: 4,
			styleActiveLine: true
		});

		instance.doc.on('change', function (doc, obj) {

			markClean();
		});

		initToolbarButtons();

	});

})(CodeEditor || (CodeEditor = {}));