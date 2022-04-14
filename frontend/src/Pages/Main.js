import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { MainLayout } from "../Components/MainLayout";
import axios from "axios";
import { CircularProgress, TextField, Grid, Button } from "@mui/material";
export const Main = (props) => {
  const [announcements, setAnnouncement] = useState([]);
  const [loading, setLoading] = useState(true);
  const [formData, setformData] = useState("");
  const navigate = useNavigate();
  const fetchData = async (input) => {
    setLoading(true);
    if (!input) {
      const response = await axios.get("announcement");
      const data = await response.data;
      setAnnouncement(data);
    } else {
      const response = await axios.get("announcement/getbytitle/" + input);
      const data = await response.data;
      setAnnouncement(data);
    }
  };
  const detailsFunc = (id) => {
    let path = `/${id}`;
    navigate(path);
  };
  const editFunc = (id) => {
    let path = `/${id}/edit`;
    navigate(path);
  };
  const deleteFunc=(id)=>{
    axios.delete(`announcement/${id}/delete`);
    window.location.reload();
  }
  const addFunc = () => {
    let path = `/new`;
    navigate(path);
  };
  const handleChange = (event) => {
    setformData(event.target.value);
    console.log(formData);
  };

  const handleSubmit = (event) => {
    event.preventDefault();
    fetchData(formData);
    setLoading(false);
  };
  useEffect(() => {
    (async () => {
      await fetchData();
      console.log("In useEffect: " + announcements);
      setLoading(false);
    })();

    return () => {
      console.log("Returned: " + announcements);
    };
  }, []);
  if (loading) return <CircularProgress size={120} />;
  else if (announcements.length < 1) {
    return <h1>No announcements</h1>;
  } else
    return (
      <MainLayout>
        <div className="headerBox">
          <Button variant="contained" className="add" onClick={() => addFunc()}>
            Add
          </Button>
          <form
            style={{ margin: "2rem 0" }}
            className="search"
            onSubmit={handleSubmit}
          >
            <TextField
              onChange={handleChange}
              fullWidth
              label="Search for Announcements"
            />
          </form>{" "}
        </div>

        <Grid container className="announcementsBox">
          {announcements.map((x) => (
            <Grid
              item
              key={x.id}
              className="announcementItem"
              xs={12}
              md={6}
              lg={6}
            >
              <h2 className="announcementTitle" onClick={() => detailsFunc(x.id)}>{x.title}</h2>
              <p className="announcementDescriptiom">{x.description}</p>
              <div className="buttons">
                <Button variant="contained" onClick={() => detailsFunc(x.id)}>Details</Button>
                <Button variant="contained" onClick={() => editFunc(x.id)}>Edit</Button>
                <Button variant="contained" color="error" onClick={() => deleteFunc(x.id)}>
                  Delete
                </Button>
              </div>
            </Grid>
          ))}
        </Grid>
      </MainLayout>
    );
};
