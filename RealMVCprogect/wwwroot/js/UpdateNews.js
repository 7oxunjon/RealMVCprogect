


    function previewImage(event, id) {
        var reader = new FileReader();
        reader.onload = function () {
            var output = document.getElementById('image-preview-' + id);
            output.src = reader.result;
            output.style.display = 'block';
        }
        reader.readAsDataURL(event.target.files[0]);
    }


    interact('.resizable')
    
        .resizable({
            
            edges: { left: true, right: true, top: true, bottom: true },
            listeners: {
               
                move(event) {
                    let target = event.target;
                    let { width, height } = event.rect;

                    // Rasmni yangi o'lchamlarda yangilash
                    target.style.width = `${width}px`;
                    target.style.height = `${height}px`;
                }
            },
            modifiers: [
                interact.modifiers.restrictSize({
                    min: { width: 50, height: 50 },  // Minimal o'lcham
                    max: { width: 600, height: 600 } // Maksimal o'lcham
                })
            ]
        })
        .draggable({
            listeners: {
                move(event) {
                    let target = event.target;
                    let x = (parseFloat(target.getAttribute('data-x')) || 0) + event.dx;
                    let y = (parseFloat(target.getAttribute('data-y')) || 0) + event.dy;

                    target.style.transform = `translate(${x}px, ${y}px)`;
                    target.setAttribute('data-x', x);
                    target.setAttribute('data-y', y);
                }
            }
        });