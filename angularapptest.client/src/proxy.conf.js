const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast",
      "/crud",
    ],
    target: "https://localhost:7283",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
