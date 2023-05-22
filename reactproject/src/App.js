import logo from './logo.svg';
import './App.css';
import React from "react";
import axios from "axios";

class App extends React.Component{

  constructor(props) {
    super(props);
    this.state = {apiResponse: ""};
  }

  callTimeAPI = ()=> {
      const data = {
          _username: 'radumitriu',
          _password: 'suntsmecher'
      }
      let url = `http://localhost:4000/login`;

      const requestOptions = {
          method: 'POST',
          headers: {'Content-Type': 'application/json'},
          body: JSON.stringify(data)
      };
      fetch(url, requestOptions)
          .then(res => res.json())
          .then(res => this.setState({apiResponse: JSON.stringify(res)}));
  }

  render() {
    return (
        <div>
          <button onClick={this.callTimeAPI}>
            Testare
          </button>
          {this.state.apiResponse}
        </div>
    );
  }
}

export default App;
