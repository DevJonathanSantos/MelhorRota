import "./App.css";
import Select from "react-select";
import React, { useEffect } from "react";

let array = [];

let optionsSelect = [];

let styled = {
  width: "35%",
  height: "16px",
  margin: "15px",
  padding: "19px",
  border: "1px solid #fff",
  textAlign: "center",
  color: "#fff",
};

function App() {
  const [melhorRota, setMelhorRota] = React.useState({});
  const [rota, setRota] = React.useState({});
  const [aeroportos, setAeroportos] = React.useState();
  const [aeroportoRotas, setAeroportoRotas] = React.useState();

  useEffect(() => {
    fetch("https://localhost:44378/api/Aeroporto/buscar")
      .then((T) => T.json())
      .then((i) => setAeroportos(i));

    fetch("https://localhost:44378/api/Aeroporto/buscar-rotas")
      .then((T) => T.json())
      .then((i) => (array = i));
  }, []);

  useEffect(() => {
    array.forEach((item) => {
      item.NomeOrigem = aeroportos.find((f) => f.codigo === item.origem).nome;
      item.NomeDestino = aeroportos.find((f) => f.codigo === item.destino).nome;
      return item;
    });
    setAeroportoRotas(array);
  }, [aeroportos]);

  useEffect(() => {
    if (aeroportos) {
      optionsSelect = aeroportos.map((item) => {
        let aeroporto = {
          value: item.codigo,
          label: item.nome,
        };
        return aeroporto;
      });
    }
  }, [aeroportos]);

  useEffect(() => {
    if (rota.origem && rota.destino) {
      BuscarMelhorRota(rota);
    }
  }, [rota]);

  const BuscarMelhorRota = (rota) => {
    fetch(
      `https://localhost:44378/api/Aeroporto/buscar-melhor-rota/${rota.origem}/${rota.destino}`
    )
      .then((T) => T.json())
      .then((i) => setMelhorRota(i));
  };

  return (
    <div className="App">
      <div style={{ display: "flex" }}>
        <div
          style={{
            width: "35%",
            height: "16px",
            margin: "15px",
            padding: "19px",
            textAlign: "center",
            color: "#fff",
          }}
        >
          <h3>Origem</h3>
        </div>
        <div
          style={{
            width: "1%",
            height: "16px",
            margin: "15px",
            padding: "19px",
            textAlign: "center",
            color: "#fff",
          }}
        >
          {}
        </div>
        <div
          style={{
            width: "35%",
            height: "16px",
            margin: "15px",
            padding: "19px",
            textAlign: "center",
            color: "#fff",
          }}
        >
          <h3>Destino</h3>
        </div>
        <div
          style={{
            width: "10%",
            height: "16px",
            margin: "15px",
            padding: "19px",
            textAlign: "center",
            color: "#fff",
          }}
        >
          <h3>Valor</h3>
        </div>
      </div>

      {aeroportoRotas
        ? aeroportoRotas.map((item, index) => (
            <div style={{ display: "flex" }} key={index}>
              <div style={styled}>{item.NomeOrigem}</div>
              <div
                style={{
                  width: "1%",
                  height: "16px",
                  margin: "15px",
                  padding: "19px",
                  textAlign: "center",
                  color: "#fff",
                }}
              >
                {">"}
              </div>
              <div style={styled}>{item.NomeDestino}</div>
              <div
                style={{
                  width: "10%",
                  height: "16px",
                  margin: "15px",
                  padding: "19px",
                  border: "1px solid #fff",
                  textAlign: "center",
                  color: "#fff",
                }}
              >
                {item.valor}
              </div>
            </div>
          ))
        : null}

      <div style={{ margin: "15px" }}>
        <h3>Buscar melhor rota</h3>
        <div style={{ width: "35%", display: "inline-block", margin: "15px" }}>
          <label style={{ color: "#fff", bottom: "5px", position: "relative" }}>
            Origem
          </label>
          <Select
            onChange={({ value }) => {
              setRota({ ...rota, origem: value });
            }}
            options={optionsSelect}
          />
        </div>
        <div style={{ width: "35%", display: "inline-block", margin: "15px" }}>
          <label style={{ color: "#fff", bottom: "5px", position: "relative" }}>
            Destino
          </label>
          <Select
            onChange={({ value }) => {
              setRota({ ...rota, destino: value });
            }}
            options={optionsSelect}
          />
        </div>
      </div>

      {melhorRota && melhorRota.Paradas ? (
        <div style={{ display: "flex", justifyContent: "center" }}>
          {melhorRota.Paradas.map((item, index) => (
            <>
              <div
                style={{
                  border: "1px solid #fff",
                  width: "95px",
                  margin: "15px",
                  textAlign: "center",
                  fontSize: "30px",
                }}
              >
                {item}
              </div>
            </>
          ))}
          <h2>Valor: {melhorRota.Valor}</h2>
        </div>
      ) : null}
    </div>
  );
}

export default App;
