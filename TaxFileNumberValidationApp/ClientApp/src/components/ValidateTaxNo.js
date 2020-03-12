import React, { Component } from 'react';

export class ValidateTaxNo extends Component {
  static displayName = ValidateTaxNo.name;

  constructor(props) {
    super(props);
      this.state = { count: 0, TaxNo: '', loading: false};
    this.incrementCounter = this.incrementCounter.bind(this);
    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
    }

  incrementCounter() {
    this.setState({
        count: this.state.count + 1
    });
    }

    ResetCounter() {
        this.setState({
            count: 0
        });
    }

    handleChange(event) {
        this.setState({ TaxNo: event.target.value });
    }

    // find 4 consecutive digits 
    compareValues() {
        var currentValue = this.state.TaxNo;
        var oldValue = localStorage.getItem("LastTaxNo");

        if (currentValue === oldValue) {
            return true;
        }
        for (let i = 0; i < currentValue.length - 4; i++) {
            if (oldValue.includes(currentValue.substring(i, i + 4))) {
                this.incrementCounter();
                return true;
            }
        }
        this.ResetCounter();

        return false;
    }

    handleSubmit(event) {
        
        if (this.state.count >= 2) {
            alert('Too many similar values enterred. Last tax number: ' + localStorage.getItem("LastTaxNo") +
                ' Current tax number: ' + this.state.TaxNo);
        }
        else {
            // compare values to avoid user guessing algorithm
            if (this.compareValues()) {
                this.validateTfn();
            }
        }
        localStorage.setItem("LastTaxNo", this.state.TaxNo);
        event.preventDefault();
        this.setState({ TaxNo: '' });
    }

    render() {
        let contents = this.state.loading
            ? "Loading"
            : "Validate";

        return (
          <div>
            <h1>Coding Assignment!</h1>

            <p>Validate an Australian tax file number.</p>
                <label for="tfn"><strong>TaxFileNumber: </strong></label>
                <input class="form-control col-lg-2" value={this.state.TaxNo} type="text" id="tfn" onChange={this.handleChange}/> <br/>
            <button className="btn btn-primary" onClick={this.handleSubmit}>{contents}</button> 
          </div>
        );
    }

    async validateTfn() {
        this.setState({ loading: true });
        var num = this.state.TaxNo;
        const response = await fetch('validatetfn\\' + this.state.TaxNo)
            .catch(err => {
                console.log(err.message);
            });;
        const data = await response.text();
        if (data === "true")
            alert("Tax file number:  " + num + " is valid");
        else 
            alert("Tax file number:  " + num + " is invalid");
        this.setState({ loading: false });
    }
}
