var createError = require('http-errors');
var express = require('express');
var path = require('path');
var cookieParser = require('cookie-parser');
var logger = require('morgan');
var axios = require('axios');
var cors = require('cors');

var indexRouter = require('./routes/index');
var usersRouter = require('./routes/users');

var app = express();
app.use(cors({
    origin: '*'
}));

var bodyParser = require('body-parser');
app.use(bodyParser.urlencoded({ extended: false }));

// view engine setup
app.set('views', path.join(__dirname, 'views'));
app.set('view engine', 'jade');

app.use(logger('dev'));
app.use(express.json());
app.use(express.urlencoded({ extended: false }));
app.use(cookieParser());
app.use(express.static(path.join(__dirname, 'public')));

app.use('/', indexRouter);
app.use('/users', usersRouter);

app.get('/form', (req, res) => {
    res.send(`
    <form action="/login" method="post">
      <label for="username">Username:</label>
      <input type="text" id="username" name="username" required>
      <br>
      <label for="password">Parola:</label>
      <input type="password" id="password" name="password" required>
      <br>
      <input type="submit" value="Trimite">
    </form>
  `);
});

app.post('/login', function (req, res) {
  // Prepare output in JSON format]
  const data = {
    _username: req.body._username,
    _password: req.body._password
  }
  axios
      .post(`http://localhost:7080/login`, data)
      .then(resp => {

        res.status(200).send(resp.data);
      })
      .catch(err => {

        res.status(500).send(`Eroare: ${err}`);
      })
})



// catch 404 and forward to error handler
app.use(function(req, res, next) {
  next(createError(404));
});

// error handler
app.use(function(err, req, res, next) {
  // set locals, only providing error in development
  res.locals.message = err.message;
  res.locals.error = req.app.get('env') === 'development' ? err : {};

  // render the error page
  res.status(err.status || 500);
  res.render('error');
});

module.exports = app;

