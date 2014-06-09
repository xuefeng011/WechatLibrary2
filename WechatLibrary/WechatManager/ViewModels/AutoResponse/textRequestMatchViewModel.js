(function () {
    "use strict";
    Ext.onReady(function () {
        window.viewModel = window.viewModel || {
            addWindow: Ext.getCmp('addWindow'),
            txtNewTextMatch: Ext.getCmp('txtNewTextMatch'),
            addNewWehcatTextRequestMatchCommand: function (parameters) {
                txtNewTextMatch.setRawValue('');
                window.viewModel.addWindow.show();
            },
            saveNewWechatTextRequestMatchCommand: function (parameters) {
                Ext.Ajax.request({
                    url: '',
                    method: 'POST',
                    params: {},
                    success: function (response, options) {
                        var responseText = response.responseText;
                        var responseObj = Ext.decode(responseText);
                    },
                    failure: function (response, options) {
                        Ext.Msg.alert('Error', 'add failed!');
                    }
                });
            }
        };
    });
}());
