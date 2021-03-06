require('es6-promise').polyfill();

import React, { Component } from 'react';

class ChatInput extends Component {
  constructor(props) {
    super(props);

    this.state = {
      chatValue: ''
    }

    this.handleChatValueChange = this.handleChatValueChange.bind(this);
    this.handleSubmitChat = this.handleSubmitChat.bind(this);
    this.handleKeyPress = this.handleKeyPress.bind(this);
  }

  handleChatValueChange(ev) {
    this.setState({
      chatValue: ev.target.value
    });
  }

  makeServerCall(cb) {
    var content = this.state.chatValue;
    var myHeaders = new Headers();
    let data = {
      message: content,
      user: this.props.client,
      time: Date.now()
    }
    myHeaders.append('Content-Type', 'application/json');
    let callConfiguration = {
      method: 'POST',
      headers: myHeaders,
      body: JSON.stringify(data)
    };

    return (
      fetch("//localhost:5000/api/Message", callConfiguration)
        .then(response => {
          console.log(response);
          if (response.status >= 400) {
            this.setState({
              chatValue: 'No Endpoint Found',
            });
            throw new Error('No Endpoint Found');
          }

          return response.text();
        })
        .then(cb)
        .catch(() => {
          this.setState({
            chatValue: 'Some Error Occurred'
          })
        })
    );
  }

  handleSubmitChat() {

    this.makeServerCall(message => { });

    this.setState({
      chatValue: ''
    })
  }

  handleKeyPress(ev) {
    if (ev.key === 'Enter') {
      this.handleSubmitChat();
    }
  }

  render() {
    return (
      <div className="input-group">
        <input type="text" className="form-control" aria-label="Chat input box" value={this.state.chatValue} onChange={this.handleChatValueChange} onKeyPress={this.handleKeyPress} />
        <div className="input-group-btn">
          <button type="button" className="btn btn-success" onClick={this.handleSubmitChat}><i className="glyphicon glyphicon-comment" /></button>
        </div>
      </div>
    );
  }
}

export default ChatInput;