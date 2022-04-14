import React, { useState } from "react";
import { MainLayout } from "../Components/MainLayout";
import axios from "axios";
import { Navigate, useParams } from "react-router-dom";
import { Box } from "@mui/system";
import { TextField } from "@mui/material";
export const Edit = () => {
  const [error, setError] = useState(null);
  const [announcements, setAnnouncement] = useState({
    title: "",
    description: "",
  });
  const [created, setCreated] = useState(false);
  const { id } = useParams();
  const handleChangeFunc = (event) => {
    const { name, value } = event.target;

    setAnnouncement((prevValue) => ({
      ...prevValue,
      [name]: value,
    }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError(null);
    const data = {
      Title: announcements.title,
      Description: announcements.description,
    };
    try {
      await axios.put(`announcement/${id}/update`, data);
      setCreated(true);
    } catch (err) {
      if (err.response.status === 401 || err.response.status === 400) {
        setError(err.response.data.message);
      } else {
        setError("something went wrong. Please try again");
      }
      console.log("error >>>", err);
    }
  };
  if (created) {
    return <Navigate to={"/"} />;
  }
  return (
    <MainLayout>
      <form onSubmit={handleSubmit}>
        <div class="row gutters">
            <h6 class="mt-3 mb-2 text-primary">Edit</h6>
            <div class="form-group">
              <label for="Title">Title</label>
              <input
                class="form-control"
                id="Title"
                placeholder="Enter Title"
                name="title"
                required
                onChange={handleChangeFunc}
              />
            </div>
              <div class="form-group">
                <label for="Description">Description</label>
                <input
                  class="form-control"
                  id="Description"
                  placeholder="Enter Description"
                  name="description"
                  required
                  onChange={handleChangeFunc}
                />
              </div>
          </div>
        <button className="btn btn-primary btn-block btn-lg">
          Edit announcement
        </button>
      </form>
    </MainLayout>
  );
};
