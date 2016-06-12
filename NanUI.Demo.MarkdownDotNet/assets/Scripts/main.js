/// <reference path="../lib/codemirror.js" />
/// <reference path="jquery-2.2.3.js" />
var Editor;

(function (theEditor) {

	var codeEditor;

	var newButton, saveButton, openButton;

	var modifyState;

	function initSplitter() {
		$('.ui-main').split({
			orientation: 'vertical',
			position: '400px',
			limit: 400
		});
	}

	function disableMenuNSelection() {
		function handler(e) {

			var target = e.srcElement;

			while (typeof target.tagName == 'undefined') {
				target = target.parentElement;
			}

			if (e.srcElement.tagName === 'INPUT') {

				var t = target.type;
				if (t != "text" && t != "password" && t != "textarea") {
					return false;
				}
			}
			else {
				if ($(target).closest('.CodeMirror-code').length || $(target).closest('.CodeMirror-line').length) {
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

	function initCodeEditor() {
		CodeMirror.modeURL = "../mode/%N/%N.js";
		codeEditor = CodeMirror.fromTextArea(document.getElementById("code-editor"), {
			mode: 'markdown',
			lineNumbers: true,
			lineWrapping: true,
			indentUnit: 4,
			styleActiveLine: true,
			extraKeys: { "Enter": "newlineAndIndentContinueMarkdownList" }

		});

		codeEditor.doc.on('change', function (doc, obj) {
			$('#markdown-preview').html(markdown.toHTML(doc.getValue()));
			if (typeof hostEditor !== 'undefined') {
				hostEditor.setCleanState(doc.isClean());
			}

			modifyState.removeClass("fa-lock").addClass("fa-edit");
		});

		codeEditor.doc.on('cursorActivity', function (sender) {
			var pos = sender.getCursor();
			console.log(pos);
			$('#currentLineLabel').text((pos.line || 0) + 1);
			$('#currentCharLabel').text((pos.ch || 0) + 1);
		});

	}

	function getCodeEditor() {
		return codeEditor;
	}

	function setTitle(str) {
		if (str) {

			$('#captionLabel').text(str);
		}
		else {
			$('#captionLabel').text('新建');
		}
	}

	function makeDocumentClean() {
		if (typeof hostEditor !== 'undefined') {
			hostEditor.setCleanState(true);
		}
		modifyState.removeClass("fa-edit").addClass("fa-lock");

		codeEditor.markClean();

	}

	function initButtons() {
		newButton = $('#btnNew');
		openButton = $('#btnOpen');
		saveButton = $('#btnSave');



		newButton.click(function () {
			if (typeof hostEditor !== 'undefined') {
				var result = hostEditor.newFile(codeEditor.doc.getValue());
				if (result) {
					setTitle();
					codeEditor.doc.setValue('');
					makeDocumentClean();
				}
			}
		});

		openButton.click(function () {
			if (typeof hostEditor !== 'undefined') {
				var result = hostEditor.openFile(codeEditor.doc.getValue());
				if (result.success) {
					setTitle(result.fileName);
					codeEditor.doc.setValue(result.contents);
					makeDocumentClean();
				}
			}
		});

		saveButton.click(function () {
			if (typeof hostEditor !== 'undefined') {
				var result = hostEditor.saveFile(codeEditor.doc.getValue());
				if (result.success) {
					setTitle(result.fileName);
					makeDocumentClean();
				}
			}
		});
	}




	$(function () {
		modifyState = $('#modifyStateLabel');
		disableMenuNSelection();
		initSplitter();
		initCodeEditor();
		initButtons();
	});

})(Editor || (Editor = {}));