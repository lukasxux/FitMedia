<template>
  <div>
    <input type="file" ref="fileInput" accept=".png, .jpg" />
    <button @click="uploadImage">Upload</button>
  </div>
</template>

<script>
export default {
  methods: {
    uploadImage() {
      console.log("Uploading image...");
    },
  },
};
</script>
