/**
 * @license Copyright (c) 2003-2021, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
};
//CKEDITOR.editorConfig = function (config) {
//    config.toolbarGroups = [
//        { name: 'document', groups: ['mode', 'document', 'doctools'] },
//        { name: 'clipboard', groups: ['PasteFromWord', '-', 'Undo', 'Redo'] },
//        { name: 'editing', groups: ['find', 'selection', 'spellchecker', 'editing'] },
//        { name: 'forms', groups: ['forms'] },
//        { name: 'basicstyles', groups: ['basicstyles', 'cleanup'] },
//        { name: 'tools', groups: ['tools'] },
//        { name: 'links', groups: ['links'] },
//        { name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi', 'paragraph'] },
//        { name: 'insert', groups: ['insert'] },
//        { name: 'colors', groups: ['colors'] },
//        { name: 'styles', groups: ['styles'] },
//        { name: 'others', groups: ['others'] },
//        { name: 'about', groups: ['about'] }
//    ];
//    config.uiColor = '#f0f8ff36';
//    config.skin = 'kama';
//    config.removeButtons = 'NewPage,Preview,Print,Templates,Flash,About,Language,Anchor,Smiley,PageBreak,Blockquote,CreateDiv,HorizontalRule,HiddenField,ImageButton,Button,Select,Textarea,TextField,Radio,Checkbox,Save';
//    config.removeDialogTabs = 'image:advanced;link:advanced';
//    config.tabIndex = 0;
//    config.contentsLangDirection = 'rtl';
//    config.dialog_magnetDistance = 30;
//    config.dialog_buttonsOrder = 'rtl';
//    config.language = 'fa';
//    config.extraPlugins = 'html5video,widget,widgetselection,clipboard,pastefromword,lineutils';
//    config.filebrowserImageUploadUrl = '/Io/UploadFile';
//    config.filebrowserUploadUrl = '/Io/UploadFile';
//    config.dialog_buttonsOrder = 'rtl';
//    config.height = '500px';
//    config.contentsCss = '/Areas/Panel/Assets/Content/style.css';
//    config.font_names = 'IRANSans/IRANSans;' + config.font_names;
//    config.applyPasteFilterAfterPasteFromWord = false;
//    config.filebrowserUploadMethod = 'form';
//    config.allowedContent = true;
//    config.removeFormatAttributes = '';
//};
//$.fn.modal.Constructor.prototype.enforceFocus = function () {
//    $(document)
//        .off('focusin.bs.modal') // guard against infinite focus loop
//        .on('focusin.bs.modal', $.proxy(function (e) {
//            if (
//                this.$element[0] !== e.target && !this.$element.has(e.target).length
//                // CKEditor compatibility fix start.
//                && !$(e.target).closest('.cke_dialog, .cke').length
//                // CKEditor compatibility fix end.
//            ) {
//                this.$element.trigger('focus');
//            }
//        }, this));
//};