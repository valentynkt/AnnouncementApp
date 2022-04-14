import "./App.css";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { Main } from "./Pages/Main";
import { Details } from "./Pages/Details";
import { Edit } from "./Pages/Edit";
import { Add } from "./Pages/Add";

function App() {
  return (
    <BrowserRouter>
      <div className="App">
        <Routes>
          <Route path="/" element={<Main />} />
          <Route path="/:id" element={<Details />} />
          <Route path="/:id/edit" element={<Edit />} />
          <Route path="/new" element={<Add />} />
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;
