const AppLoader = (props: {
  height?: string;
  width?: string;
  showDefaultLoader?: boolean;
}) => {
  const loaderDimensions = {
    width: props?.width ?? "300px",
    height: props?.height ?? "300px",
  };

  return (
    <>
      <lottie-player
        src="https://assets3.lottiefiles.com/private_files/lf30_l8csvun7.json"
        background="transparent"
        speed="1"
        style={loaderDimensions}
        loop
        autoplay
      ></lottie-player>
    </>
  );
};

export default AppLoader;
