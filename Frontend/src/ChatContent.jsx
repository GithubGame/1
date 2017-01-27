import React, { Component } from 'react';
import { emojify } from 'react-emojione';

class ChatContent extends Component {
  constructor(props) {
    super(props);

    this.callme = this.callme.bind(this);
    this.pollme = this.pollme.bind(this);
  }
  componentDidMount() {
     this.pollme();
  }

  callme(cb) {

    var myHeaders = new Headers();

    myHeaders.append('Content-Type', 'application/json');
    let callConfiguration = {
      method: 'GET'
    };

    return (
      fetch("//localhost:5000/api/Message", callConfiguration)
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
          this.setState({
            chatValue: 'Some Error Occurred'
          })
        })
    );
  }
  pollme() {
    this.callme(message => {
      var input = JSON.parse(message);
      input.forEach(element=>{

        console.log(element)

        this.props.addMessage(element.message, element.user, new Date(element.time)) 
      }
      );
      console.log(input);
      
    })
    window.setInterval(this.pollme, 20000)
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