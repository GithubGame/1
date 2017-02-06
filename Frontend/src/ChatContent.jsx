import React, { Component } from 'react';
import { emojify } from 'react-emojione';

class ChatContent extends Component {
  constructor(props) {
    super(props);

    this.callme = this.callme.bind(this);
    this.pollme = this.pollme.bind(this);
    this.state = {
      lastMessageId: 0
    };
  }
  componentDidMount() {
    window.setInterval(this.pollme, 1000)
  }

  callme(cb) {

    var myHeaders = new Headers();

    myHeaders.append('Content-Type', 'application/json');
    let callConfiguration = {
      method: 'GET'
    };

    return (
      fetch("//localhost:5000/api/Message/" + this.state.lastMessageId, callConfiguration)
        .then(response => {

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
          
        })
    );
  }
  pollme() {
    this.callme(message => {
      var input = JSON.parse(message);
      input.forEach(element=>{
        console.log(element);
        this.setState({
            lastMessageId: element.id
          })
        
        this.props.addMessage(element.message, element.user, new Date(element.time)) 
      }
      );
      console.log(input);

    })
  }
  render() {
    return (
      <div className="panel panel-default chat-content">
        <div className="panel-body">
          {this.props.messages.map((m, idx) => {
            console.log(m);
            return <div key={idx}>[{m.timestamp.toLocaleDateString()} {m.timestamp.toLocaleTimeString()}][{m.user}]: {emojify(m.message)}</div>
          })}
        </div>
      </div>
    );
  }
}

export default ChatContent;