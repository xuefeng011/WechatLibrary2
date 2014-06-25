(function () {
    "use strict";
    Ext.onReady(function () {
        window.viewModel = window.viewModel || {
            textMessageGroupSendCommand: function (parameters) {
                var commandName = parameters[1];
                var data = parameters[2].data;

                if (commandName == 'send') {
                    Ext.Ajax.request({
                        url: '/Service/GroupSendService/SendText.ashx',
                        method: 'POST',
                        params: {
                            Id: data.Id
                        },
                        success: function (response, options) {
                            var responseText = response.responseText;
                            var responseObj = Ext.decode(responseText);
                            if (responseObj.success) {
                                Ext.Msg.alert('Success', responseObj.info);
                            } else {
                                Ext.Msg.alert('Error', responseObj.info);
                            }
                        },
                        failure: function (response, options) {
                            Ext.Msg.alert('Error', "group send text fail!");
                        }
                    });
                }
            },
            imageMessageGroupSendCommand: function (parameters) {
                var commandName = parameters[1];
                var data = parameters[2].data;

                if (commandName == 'send') {
                    Ext.Ajax.request({
                        url: '/Service/GroupSendService/SendImage.ashx',
                        method: 'POST',
                        params: {
                            Id: data.Id
                        },
                        success: function (response, options) {
                            var responseText = response.responseText;
                            var responseObj = Ext.decode(responseText);
                            if (responseObj.success) {
                                Ext.Msg.alert('Success', responseObj.info);
                            } else {
                                Ext.Msg.alert('Error', responseObj.info);
                            }
                        },
                        failure: function (response, options) {
                            Ext.Msg.alert('Error', "group send image fail!");
                        }
                    });
                }
            },
            voiceMessageGroupSendCommand: function (parameters) {
                var commandName = parameters[1];
                var data = parameters[2].data;

                if (commandName == 'send') {
                    Ext.Ajax.request({
                        url: '/Service/GroupSendService/SendVoice.ashx',
                        method: 'POST',
                        params: {
                            Id: data.Id
                        },
                        success: function (response, options) {
                            var responseText = response.responseText;
                            var responseObj = Ext.decode(responseText);
                            if (responseObj.success) {
                                Ext.Msg.alert('Success', responseObj.info);
                            } else {
                                Ext.Msg.alert('Error', responseObj.info);
                            }
                        },
                        failure: function (response, options) {
                            Ext.Msg.alert('Error', "group send voice fail!");
                        }
                    });
                }
            },
            newsMessageGroupSendCommand: function (parameters) {
                var commandName = parameters[1];
                var data = parameters[2].data;

                if (commandName == 'send') {
                    Ext.Ajax.request({
                        url: '/Service/GroupSendService/SendNews.ashx',
                        method: 'POST',
                        params: {
                            Id: data.Id
                        },
                        success: function (response, options) {
                            var responseText = response.responseText;
                            var responseObj = Ext.decode(responseText);
                            if (responseObj.success) {
                                Ext.Msg.alert('Success', responseObj.info);
                            } else {
                                Ext.Msg.alert('Error', responseObj.info);
                            }
                        },
                        failure: function (response, options) {
                            Ext.Msg.alert('Error', "group send news fail!");
                        }
                    });
                }
            }
        };
    });
}());
